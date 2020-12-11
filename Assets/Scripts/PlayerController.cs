﻿using System.Collections;
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
    public LayerMask collisionLayer;
    private MakeShiningTile makeShiningTile;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        makeShiningTile = backgroundTilemap.GetComponent<MakeShiningTile>();
    }

    void Update()
    {
        var shiningTiles = makeShiningTile.getShiningTiles();

        if(shiningTiles.Count != 0)
        {
        foreach (var i in shiningTiles)
        {
            if (i[0] == transform.position.x && i[1] == transform.position.y && Input.GetKeyDown(KeyCode.Space))
            {
                elixirManager.GetComponent<ElixirSystem>().shiningTileTrigger();
                FindObjectOfType<AudioManager>().Play("shiningPick");
                makeShiningTile.removeShiningTileAt(i);
            }
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
                FindObjectOfType<AudioManager>().Play("walkingSound");

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

                if (isWalkable(targetPos))
                {
                    StartCoroutine(Move(targetPos));

                }


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

    private bool isWalkable(Vector3 targetPos)
    {
        //SolidObjects is layer name defined by LayerMask
        if (Physics2D.OverlapCircle(targetPos, 0.2f, collisionLayer) != null)
        {
            return false;
       }

        return true;
    }

}


