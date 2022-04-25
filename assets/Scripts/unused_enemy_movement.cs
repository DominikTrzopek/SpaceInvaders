using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class unused_enemy_movement01 : MonoBehaviour
{
    public Rigidbody2D enemy;
    public float speed;
    void FixedUpdate()
    {
        if(GameObject.Find("train").transform.position.x - gameObject.transform.position.x > 0)
            enemy.AddForce(transform.right * speed , ForceMode2D.Force);
        else if (GameObject.Find("train").transform.position.x - gameObject.transform.position.x < 0)
            enemy.AddForce(-transform.right * speed , ForceMode2D.Force);
    }
}
