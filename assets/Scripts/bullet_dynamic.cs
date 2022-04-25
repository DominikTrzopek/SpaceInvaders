using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet_dynamic : MonoBehaviour
{
    public Rigidbody2D bullet;
    public float speed;
    Vector2 direction;


    private void Start()
    {
        direction = (GameObject.Find("pivot").transform.position - GameObject.Find("cannon").transform.position).normalized;
        bullet.AddForce(direction * speed, ForceMode2D.Impulse);
    }

}
