using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightBarController : MonoBehaviour
{

    public float moveSpeed;
    private bool isMoving;
    private int direction; //positive for up, negative for down

    private Vector3 targetPos; 

    private GameObject fightBarImg;
    private float barHeight;
    private float barY;

    void Awake()
    {
        isMoving = true;
        fightBarImg = GameObject.Find("FightBarBackground");
        direction = -1;

        barHeight = fightBarImg.GetComponent<RectTransform>().rect.width; //it's rotated so width here refers to height
        barY = fightBarImg.transform.position.y;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isMoving = false;
            Debug.Log(transform.position.y);
        }

        if (isMoving)
        {
            if (direction == 1)
            {
                targetPos = new Vector3(transform.position.x, barY + (barHeight / 2), 0);
            }
            else if (direction == -1)
            {
                targetPos = new Vector3(transform.position.x, barY - (barHeight / 2), 0);
            }
            StartCoroutine(Move(targetPos));
        }
    }

    IEnumerator Move(Vector3 tar)
    {
        while ((tar - transform.position).sqrMagnitude > Mathf.Epsilon && isMoving)
        {
            transform.position = Vector3.MoveTowards(transform.position, tar, moveSpeed * Time.deltaTime);
            yield return null;
        }
        if (isMoving)
        {
            transform.position = tar;
            direction = -direction;
        }
    }
}
