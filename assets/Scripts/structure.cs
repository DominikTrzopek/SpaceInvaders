using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class structure : MonoBehaviour
{
    const float pozy = -8;
    public int HP;
    public float speed;
    public GameObject prefab, prefab2;
    float range_rubble, range_fire_x, range_fire_y, distance_fire_x, distance_fire_y;
    
    void Start()
    {
        range_rubble = gameObject.GetComponent<BoxCollider2D>().size.x;
        range_fire_x = gameObject.GetComponent<BoxCollider2D>().size.x;
        range_fire_y = gameObject.GetComponent<BoxCollider2D>().size.y;
        distance_fire_x = Random.Range(0.5f, 2 * range_fire_x);
        distance_fire_y = Random.Range(0.5f, 1.5f * range_fire_y);
    }
    void Update()
    {
        if(HP == 1)
        {
            
            Vector3 spawnpoint_fire = new Vector3(transform.position.x + distance_fire_x, transform.position.y + distance_fire_y, transform.position.z);
            Instantiate(prefab2, spawnpoint_fire, transform.rotation);
        }
        if(HP == 0)
        {   
            Rigidbody2D rbody = gameObject.GetComponent<Rigidbody2D>();
            rbody.constraints = RigidbodyConstraints2D.None;
            float distance_rubble = Random.Range(0, 2.5f * range_rubble);
            Vector3 spawnpoint_rubble = new Vector3(transform.position.x + distance_rubble, pozy,transform.position.z);
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            rbody.AddForce(-transform.up * speed);
            // rbody.transform.rotation = new Quaternion(0,0,rotation,0);
            Instantiate(prefab, spawnpoint_rubble, transform.rotation); ;
            if (transform.position.y < -10)
                Destroy(gameObject);

        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "bullet")
        {
            HP -= 1;
            if (GameObject.Find("HP_City (1)") != null)
                Destroy(GameObject.Find("HP_City (1)"));
            else if (GameObject.Find("HP_City (2)") != null)
                Destroy(GameObject.Find("HP_City (2)"));
            else if (GameObject.Find("HP_City (3)") != null)
                Destroy(GameObject.Find("HP_City (3)"));
            else if (GameObject.Find("HP_City (4)") != null)
                Destroy(GameObject.Find("HP_City (4)"));
            else if (GameObject.Find("HP_City (5)") != null)
                Destroy(GameObject.Find("HP_City (5)"));
            else if (GameObject.Find("HP_City (6)") != null)
                Destroy(GameObject.Find("HP_City (6)"));
            else if (GameObject.Find("HP_City (7)") != null)
                Destroy(GameObject.Find("HP_City (7)"));
            else if (GameObject.Find("HP_City (8)") != null)
                Destroy(GameObject.Find("HP_City (8)"));
        }

    }
}
