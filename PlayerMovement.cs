using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer sprite;
    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private float jumpStrength = 20f;

    private bool isOnGround;

    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        isOnGround = true;
    }

    // Update is called once per frame
    void Update()
    {
        //speed of the sprite
        float dirX = rb.velocity.x;
        float dirY = rb.velocity.y;
        //can only jump at select times
        if ((Input.GetKeyDown("w") || Input.GetKeyDown("space") || Input.GetKeyDown("up")) && isOnGround == true)
        {

            //rb.velocity = new Vector2(rb.velocity.x, jumpStrength);
            //changed to use forces
            rb.AddForce(new Vector2(0, jumpStrength), ForceMode2D.Impulse);
            //jump disables after humping
            isOnGround = false;
        }

        //lets the player jump when the character is vertically stationary, possibly adds a skill element with mid air jumps
        if (dirY == 0)
        {
            isOnGround = true;
        }
        //accepts multiple keys, same as jump
        if (Input.GetKey("d") || Input.GetKey("right"))
        {

            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);

        }

        if (Input.GetKey("a") || Input.GetKey("left"))
        {

            rb.velocity = new Vector2(-(moveSpeed), rb.velocity.y);

        }

        //if its heading right the animation plays as normal
        if (dirX > 0f)
        {
            anim.SetBool("running", true);
            sprite.flipX = false;
        }
        //flips sprite when moving left
        else if (dirX < 0f)
        {
            anim.SetBool("running", true);
            sprite.flipX = true;
        }
        else
        {
            anim.SetBool("running", false);
        }
        //state checks for vertical animations
        if (dirY > 0f)
        {
            anim.SetBool("jumping", true);
            anim.SetBool("falling", false);
        }
        else if (dirY < 0f)
        {
            anim.SetBool("falling", true);
            anim.SetBool("jumping", false);
        }
        else
        {
            anim.SetBool("jumping", false);
            anim.SetBool("falling", false);
        }

    }
}

