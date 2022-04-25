using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_bullet_dynamic : MonoBehaviour
{
    public Rigidbody2D bullet;
    public float speed;
    // Update is called once per frame
    void Start()
    {

        bullet.AddForce(Vector2.down * speed, ForceMode2D.Impulse);
    }
}
