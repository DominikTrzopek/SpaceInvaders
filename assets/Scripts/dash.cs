using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dash : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKey("left shift") && Input.GetKey("a"))
            gameObject.transform.position = new Vector2(gameObject.transform.position.x - 1,gameObject.transform.position.y);
        if (Input.GetKey("left shift") && Input.GetKey("d"))
            gameObject.transform.position = new Vector2(gameObject.transform.position.x + 1, gameObject.transform.position.y);
    }
}
