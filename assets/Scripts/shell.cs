using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shell : MonoBehaviour
{
    public Rigidbody2D rbody;
    public float bounce;
    float timer = 5.0f;
    int bounce_count = 0;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.name == "water" && bounce_count == 0)
        {
            rbody.AddForce(transform.up * bounce, ForceMode2D.Impulse);
            bounce_count = 1;
        }

    }
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
            Destroy(gameObject);
    }
}
