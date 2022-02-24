using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointContact : MonoBehaviour
{

    private Animator anim;
    private Rigidbody2D rb;
    private bool closed = true;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && closed)
        {
            open();
        }
    }

    private void open()
    {
        anim.SetTrigger("Reached 0");
        closed = false;
    }

    private void open2()
    {
        anim.SetTrigger("Reached 1");
    }
}
