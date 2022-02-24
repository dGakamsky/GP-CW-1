using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowdAi : MonoBehaviour
{

    //how far away it tries to keep all other entities
    //force applied to avoid contact
    public float jumpStrength;
    public float rayDistance;
    private Rigidbody2D rb;

    private float speed = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    // uses Raycast to avoid incoming collisions, going the other way to avoid hitting something
    // more complex rotiation would have been possible if the game wasnt 2D, but as is I could not figure out how to do that
    void Update()
    {

        RaycastHit2D hit_down = Physics2D.Raycast(transform.position, Vector3.down, rayDistance);
        RaycastHit2D hit_up = Physics2D.Raycast(transform.position, Vector3.up, rayDistance);
        RaycastHit2D hit_left = Physics2D.Raycast(transform.position, Vector3.left, rayDistance);
        RaycastHit2D hit_right = Physics2D.Raycast(transform.position, Vector3.right, rayDistance);


        if (hit_down)
        {

            rb.velocity = new Vector2(rb.velocity.x, speed);

        }

        if (hit_up)
        {

            rb.velocity = new Vector2(rb.velocity.x, -(speed));

        }
        if (hit_left)
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);


        }
        if (hit_right)
        {

            rb.velocity = new Vector2(-(speed), rb.velocity.y);


        }


    }
}


