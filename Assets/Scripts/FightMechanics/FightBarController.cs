using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightBarController : MonoBehaviour
{

    private float moveSpeed;
    private bool isMoving;
    private int direction; //positive for up, negative for down

    private Vector3 targetPos; 

    private GameObject fightBarImg;
    private float barHeight;
    private float barY;

    //here we define the regions of the bar
    float topRedUpper;
    float topRedLower;

    float bottomRedUpper;
    float bottomRedLower;

    float topYellowUpper;
    float topYellowLower;
    float bottomYellowUpper;
    float bottomYellowLower;

    float greenUpper;
    float greenLower;

    void Awake()
    {
        isMoving = true;
        fightBarImg = GameObject.Find("FightBarBackground");
        direction = -1;

        barHeight = fightBarImg.GetComponent<RectTransform>().rect.width; //it's rotated so width here refers to height
        barY = fightBarImg.transform.position.y;

        //Here we define some variables for ease of use in defining colour region floats
        var halfBarHeight = barHeight / 2;
        var halfBarHeightUpper = (barHeight / 2) + 0.1f;
        var halfBarHeightLower = (barHeight / 2) - 0.1f;

        //Here we define the float values of the regions using the barHeight and barY
        topRedUpper = barY + halfBarHeight;
        topRedLower = barY + (halfBarHeightUpper - (0.3f * barHeight));

        topYellowUpper = barY + (halfBarHeightLower - (0.3f * barHeight));
        topYellowLower = barY + (halfBarHeightUpper - (0.45f * barHeight));

        greenUpper = barY + (halfBarHeightLower - (0.45f * barHeight));
        greenLower = barY + ((-halfBarHeightUpper) + (0.45f * barHeight));

        bottomYellowUpper = barY + ((-halfBarHeightLower) + (0.45f * barHeight));
        bottomYellowLower = barY + ((-halfBarHeightUpper) + (0.3f * barHeight));

        bottomRedUpper = barY + ((-halfBarHeightLower) + (0.3f * barHeight));
        bottomRedLower = barY - halfBarHeight; 

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isMoving = false;
            if ((transform.position.y > topRedLower && transform.position.y < topRedUpper) || (transform.position.y > bottomRedLower && transform.position.y < bottomRedUpper))
            {
                Debug.Log("Red");
            }
            else if ((transform.position.y > topYellowLower && transform.position.y < topYellowUpper) || (transform.position.y > bottomYellowLower && transform.position.y < bottomYellowUpper))
            {
                Debug.Log("Yellow");
            }
            else if(transform.position.y > greenLower && transform.position.y < greenUpper)
            {
                Debug.Log("Green");
            }
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

    public void changeBarSpeed(float rate)
    {
        moveSpeed = rate;
    }
}