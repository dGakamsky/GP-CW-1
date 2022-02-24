using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiFollow : MonoBehaviour
{

    private float aggro;
    private float speed;

    private Transform player;

    private Rigidbody2D rb;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        aggro = 20;
        speed = 10;
    }

    void Update()
    {
        // the ball looks both ways
        RaycastHit2D enemyVision_left = Physics2D.Raycast(transform.position, Vector3.left, aggro);
        RaycastHit2D enemyVision_right = Physics2D.Raycast(transform.position, Vector3.right, aggro);


        //will roll towards the player if spotted
        if (enemyVision_left.collider.tag == "Player")
        {

            rb.velocity = new Vector2(-(speed), 0);



        }

        if (enemyVision_right.collider.tag == "Player")
        {

            rb.velocity = new Vector2(speed, 0);
        }



    }
}


