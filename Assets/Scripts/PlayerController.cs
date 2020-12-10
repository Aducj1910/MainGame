using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update


    public float moveSpeed;
    private bool isMoving;

    private bool testDialogueAlreadyCalled;

    public GameObject testDialogue;
    public GameObject backgroundTilemap;
    public GameObject elixirManager;
    private HealthManager healthManager;

    private Vector2 input;
    private Animator animator;
    public LayerMask shiningLayer;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        var shiningTilesArray = backgroundTilemap.GetComponent<MakeShiningTile>().sendShiningTilesArray();

        foreach (var i in shiningTilesArray)
        {
            if (i["x"] == transform.position.x && i["y"] == transform.position.y && Input.GetKeyDown(KeyCode.Space))
            {
                elixirManager.GetComponent<ElixirSystem>().shiningTileTrigger();
                FindObjectOfType<AudioManager>().Play("shiningPick");
                //FindObjectOfType<MakeShiningTile>().destroyShiningTile(i["x"], i["y"]);
            }
        }

        if (!isMoving)
        {

            input.x = Input.GetAxisRaw("Horizontal");
            input.y = Input.GetAxisRaw("Vertical");


            if (input.x != 0)
            {
                input.y = 0;
            }
            if (input != Vector2.zero)
            {
                animator.SetFloat("moveX", input.x);
                animator.SetFloat("moveY", input.y);

                var targetPos = transform.position;
                targetPos.x += input.x;
                targetPos.y += input.y;

                //if (Physics2D.OverlapCircle(targetPos, 0.1f, solidObjectsLayer) != null && !testDialogueAlreadyCalled)
                //{
                //    testDialogue.GetComponent<TestDialogue>().SendSignal();
                //    testDialogueAlreadyCalled = true;
                //}


                StartCoroutine(Move(targetPos));

            }
            animator.SetBool("isMoving", isMoving);
        }
    }


    IEnumerator Move(Vector3 targetPos)
    {
        isMoving = true;

        while ((targetPos - transform.position).sqrMagnitude > Mathf.Epsilon)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
            yield return null;
        }
        transform.position = targetPos;

        isMoving = false;
    }

    //private bool isWalkable(Vector3 targetPos)
    //{
    //    //SolidObjects is layer name defined by LayerMask
    //    if (Physics2D.OverlapCircle(targetPos, 0.1f, shiningLayer) != null)
    //    {
    //        return false;
    //    }

    //    return true;
    //}

}


