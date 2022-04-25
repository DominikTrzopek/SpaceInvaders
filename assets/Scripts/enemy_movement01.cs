using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_movement01 : MonoBehaviour
{
    bool movement, movement_clone;
    public Rigidbody2D enemy;
    public float speed;
    public GameObject[] enemies;
    public GameObject spawner;
    public string tag_en, wall_left, wall_right;
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.name == wall_left && gameObject.tag == "enemy")
            movement = true;
        if (other.name == wall_right && gameObject.tag == "enemy")
            movement = false;
        if (other.name == wall_left && gameObject.tag.Equals(tag_en))
            movement_clone = true;
        if (other.name == wall_right && gameObject.tag.Equals(tag_en))
            movement_clone = false;      
        //Debug.Log(other.name);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "pivot")
        {
            gameObject.tag = tag_en;
            if (tag_en == "en2")
                movement_clone = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.name == "pivot" && gameObject.transform.position.x > other.transform.position.x)
        {
            gameObject.tag = "enemy";
            if (gameObject.GetComponent<Rigidbody2D>().velocity.x > 0)
                movement = true;
            else
                movement = false;
        }
    }
    void FixedUpdate()
    {
        enemies = GameObject.FindGameObjectsWithTag(tag_en);
        if (gameObject.tag == "enemy")
        {
            if (movement == true)
                gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(speed, 0);
            if (movement == false)
                gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(-speed, 0);
        }
        if (movement_clone == true)
            foreach (GameObject en1 in enemies)
            {
                en1.GetComponent<Rigidbody2D>().velocity = new Vector2(speed, 0);
            }
        if (movement_clone == false && gameObject.tag == tag_en)
            foreach (GameObject en1 in enemies)
            {
                en1.GetComponent<Rigidbody2D>().velocity = new Vector2(-speed, 0);
            }
        int lenght = enemies.Length;
        float max = 0, min = 0;
        if(lenght > 0)
        {
            max = -25; 
            min = 25;
        }
        for(int i = 0; i < lenght; i++)
        {
            if (enemies[i].transform.position.x < min)
                min = enemies[i].transform.position.x;
            if (enemies[i].transform.position.x > max)
                max = enemies[i].transform.position.x;
        }
        //Debug.Log(spawner.name);
        if (gameObject.name == "enemy01(Clone)")
        {
            if (lenght > 4)
                GameObject.Find("AnchorSL").GetComponent<enemy_spawn>().enabled = false;
            else
                GameObject.Find("AnchorSL").GetComponent<enemy_spawn>().enabled = true;
            GameObject.Find(wall_right).GetComponent<BoxCollider2D>().size = new Vector2(10 + (max - min) * 2, 1);
        }
        if (gameObject.name == "enemy02(Clone)")
        {
            if (lenght > 4)
                GameObject.Find("AnchorSR").GetComponent<enemy_spawn>().enabled = false;
            else
                GameObject.Find("AnchorSR").GetComponent<enemy_spawn>().enabled = true;
            GameObject.Find(wall_left).GetComponent<BoxCollider2D>().size = new Vector2(10 + (max - min) * 2, 1);
        }
    }
}