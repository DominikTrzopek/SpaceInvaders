using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroy_enemy : MonoBehaviour
{
    const float scale_change = -0.0025f;
    float space = 0.1f, current_speed, new_scale = 1;
    public int HP;
    public GameObject particle, particle2;
    public Rigidbody2D rbody;
    public float speed;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "bullet")
            HP -= 1;
    }
    void Update()
    {
        space -= Time.deltaTime;
        if (HP == 1 && space < 0 && (gameObject.name != "enemyB1(Clone)" && gameObject.name != "enemyB2(Clone)"))
        {
            Instantiate(particle, transform.position, transform.rotation);
            space = 0.08f;
        }
        if (HP == 0)
        {
            gameObject.tag = "enemy";
            rbody.constraints = RigidbodyConstraints2D.None;
            Instantiate(particle2, transform.position, transform.rotation);
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            rbody.gravityScale = 0.8f;
            gameObject.GetComponent<enemy_movement01>().enabled = false;
            if(transform.childCount != 0)
                gameObject.GetComponentInChildren<enemy_sh>().enabled = false;
            gameObject.GetComponent<Renderer>().sortingOrder = -1;
            current_speed = Random.Range(-speed, speed);
            rbody.transform.Rotate(Vector3.forward * current_speed);
            new_scale += scale_change;
            gameObject.transform.localScale = new Vector3(new_scale, new_scale, 1);
            
        }
        if (transform.position.y < -7)
            Destroy(gameObject);
        //Destroy(gameObject);
        //Debug.Log(HP);
    }
}
