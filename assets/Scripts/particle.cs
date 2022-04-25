using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particle : MonoBehaviour
{
    public double fade_speed, r_change, g_change, b_change;
    public float r, g, b, new_scalex, new_scaley;
    float alpha = 1, speed_horizontal;
    public Rigidbody2D rbody;
    public float speed_vertical, range;
    Color color;
    void Update()
    {
        alpha = (float)(alpha - fade_speed);
        r = (float)(r - r_change);
        g = (float)(g - g_change);
        b = (float)(b - b_change);
        color = new Color(r, g, b, alpha);
        gameObject.GetComponent<SpriteRenderer>().color = color;
        //Debug.Log(color);
        Vector3 scale = new Vector3(new_scalex, new_scaley, new_scalex);
        gameObject.transform.localScale = scale;
        rbody.AddForce(transform.up * speed_vertical);
        speed_horizontal = Random.Range(-range, range);
        rbody.AddForce(transform.right * speed_horizontal);
        if (alpha < 0)
            Destroy(gameObject);
    }
}
