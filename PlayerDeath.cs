using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{

    private Animator anim;
    private Rigidbody2D rb;


    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //kills player if he comes into contact with dangerous things (like spikes)
        if (collision.gameObject.CompareTag("Hazard"))
        {
            Die();
        }

        //repurposed script since it seemed more efficient than writing a new script just for this bit
        //triggers on the end of level trophy
        if (collision.gameObject.CompareTag("End"))
        {
            Win();
        }
    }

    private void Die()
    {
        // triggers death animation state
        anim.SetTrigger("death");
        //disables player movement, makes death meaningful
        rb.bodyType = RigidbodyType2D.Static;
    }

    //takes you to the game over screen, happens after the death animation to let it sink in

    private void Respawn() // as of the demo this method is redundant I think
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    // repurposed respawn script, means that you win (got to the end of the level)
    private void Win()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
