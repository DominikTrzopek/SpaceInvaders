using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet_destroy : MonoBehaviour
{
    public Animator anim;
    void Start()
    {
        gameObject.GetComponent<Animator>().enabled = false;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        /*if (anim.gameObject.activeSelf)
        {        
            anim.SetBool("iftrue", true);
            //anim.Play("New Animation");
        }*/
        gameObject.GetComponent<Animator>().enabled = true;
        anim.SetBool("iftrue", true);
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        Destroy(gameObject, 0.1f);
        
        //gameObject.GetComponent<SpriteRenderer>().enabled = false;
        //Destroy(gameObject);
        //Debug.Log(collision.collider.name);
       
    }
    
}
