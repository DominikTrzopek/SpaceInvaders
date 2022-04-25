using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move_ship : MonoBehaviour
{
    const float areaborder = 30;
    public float speed;
    void Update()
    {
        gameObject.GetComponent<Rigidbody2D>().AddForce(transform.right * speed);
        if (gameObject.transform.rotation.y == 0 && gameObject.transform.position.x > areaborder)
            Destroy(gameObject);
        if (gameObject.transform.rotation.y != 0 && gameObject.transform.position.x < -areaborder)
            Destroy(gameObject);
    }
}
