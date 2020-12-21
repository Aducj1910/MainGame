using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update


    public float moveSpeed;
    private bool isMoving;

    public GameObject backgroundTilemap;
    [HideInInspector] public Vector3 facingDirection;

    private GameObject elixirManager;
    private GameObject dialogueBox;
    private GameObject inventoryManager;
    private HealthManager healthManager;

    private Vector2 input;
    private Animator animator;
    private MakeShiningTile makeShiningTile;

    public LayerMask collisionLayer;
    public LayerMask interactableLayer;
    //now private
    public LayerMask elixirSmallHammerLayer;
    private LayerMask elixirMediumDrillLayer;
    public Vector3 getFacingDirection()
    {
        return facingDirection;
    }

    private void Awake()
    {
        animator = GetComponent<Animator>();
        makeShiningTile = backgroundTilemap.GetComponent<MakeShiningTile>();
        elixirManager = GameObject.Find("ElixirManager");
        dialogueBox = GameObject.Find("DialogueManager");
        inventoryManager = GameObject.Find("InventoryManager");

        //elixirSmallHammerLayer = LayerMask.NameToLayer("ElixirTilemapSmallHammer");
        elixirMediumDrillLayer = LayerMask.NameToLayer("ElixirTilemapMediumDrill");
    }

    void Update()
    {
        var shiningTiles = makeShiningTile.getShiningTiles();
        if (shiningTiles.Contains(transform.position) && Input.GetKeyDown(KeyCode.Space))
        {
            elixirManager.GetComponent<ElixirSystem>().shiningTileTrigger();
            FindObjectOfType<AudioManager>().Play("shiningPick");
            makeShiningTile.removeShiningTileAt(transform.position);
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
                FindObjectOfType<AudioManager>().Play("walkingSound");

                animator.SetFloat("moveX", input.x);
                animator.SetFloat("moveY", input.y);

                var targetPos = transform.position;
                targetPos.x += input.x;
                targetPos.y += input.y;

                if (isWalkable(targetPos))
                {
                    StartCoroutine(Move(targetPos));

                }


            }
            animator.SetBool("isMoving", isMoving);

            if (Input.GetKeyDown(KeyCode.Z))
            {
                Interact(); 
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                ObtainElixir();
            }
        }
    }

    void Interact()
    {
        facingDirection = new Vector3(animator.GetFloat("moveX"), animator.GetFloat("moveY"));
        var interactPosition = transform.position + facingDirection;
        var collider = Physics2D.OverlapCircle(interactPosition, 0.6f, interactableLayer);

        if (collider != null)
        {
            collider.GetComponent<Interactable>()?.Interact();
        }
    }

    void ObtainElixir()
    {
        Tool currentTool = inventoryManager.GetComponent<InventoryManager>().getCurrentTool();

        if(Physics2D.OverlapCircle(transform.position, 0.6f, elixirSmallHammerLayer) != null && currentTool.toolId == 1)
        {
            Debug.Log("Yess");
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

    private bool isWalkable(Vector3 targetPos)
    {
        //SolidObjects is layer name defined by LayerMask
        if (Physics2D.OverlapCircle(targetPos, 0.2f, collisionLayer | interactableLayer) != null)
        {
            return false;

       }

        return true;
    }
}