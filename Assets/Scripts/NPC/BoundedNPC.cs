using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundedNPC : MonoBehaviour
{
    private Vector3 directionVector;
    private Transform myTransform;
    public float speed;
    private Rigidbody2D myRigidBody;
    private Animator anim;
    public Collider2D bounds;

    public GameObject playerController;
    private GameObject dialogueManager;
    private GameObject fightSetup;
    private bool fightEnded;

    [HideInInspector] public bool isInteracting = false;

    void Start()
    {
        myTransform = GetComponent<Transform>();
        myRigidBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        dialogueManager = GameObject.Find("DialogueManager");
        fightSetup = GameObject.Find("FightSetup");

        ChangeDirection();
    }

    void Update()
    {
        //Debug.Log(dialogueManager.GetComponent<DialogueManager>().dialogueEndedReturn());

        if (isInteracting && dialogueManager.GetComponent<DialogueManager>().dialogueEndedReturn())
        {
            isInteracting = false;
        }

        //We will add new condition to see if fight has ended or not
        fightEnded = fightSetup.GetComponent<FightSetup>().getFightEndedStatus();

        if (!isInteracting && fightEnded)
        {
        Move();
        }
        else
        {
            var playerFacingDirection = playerController.GetComponent<PlayerController>().getFacingDirection();
            Vector3 NPCFacingDirection = playerFacingDirection;
            NPCFacingDirection.x = - NPCFacingDirection.x;
            NPCFacingDirection.y = -NPCFacingDirection.y;

            anim.SetFloat("MoveX", NPCFacingDirection.x);
            anim.SetFloat("MoveY", NPCFacingDirection.y);
        }
    }

    public void setIsInteracting()
    {
        isInteracting = true;
    }

    private void Move()
    {
        Vector3 tempPos = myTransform.position + directionVector * speed * Time.deltaTime;

        if (bounds.bounds.Contains(tempPos))
        {
            myRigidBody.MovePosition(tempPos);
        }
        else
        {
            ChangeDirection();
        }
    }

    void UpdateAnimation()
    {
        anim.SetFloat("MoveX", directionVector.x);
        anim.SetFloat("MoveY", directionVector.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector3 temp = directionVector;
        ChangeDirection();
        int loops = 0;
        while(temp == directionVector && loops < 100)
        {
            loops++;
            ChangeDirection();
        }
    }

    void ChangeDirection()
    {
        int direction = Random.Range(0, 4);
        switch (direction)
        {
            case 0:
                //walking right
                directionVector = Vector3.right;
                break;
            case 1:
                //walking up
                directionVector = Vector3.up;
                break;
            case 2:
                ///walking left
                directionVector = Vector3.left;
                break;
            case 3:
                //walking down
                directionVector = Vector3.down;
                break;
            default:
                break;
        }
        UpdateAnimation();
    }
}
