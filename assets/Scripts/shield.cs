using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shield : MonoBehaviour
{
    const float ratio = 45;
    public float scale_change, scale_max;
    float new_scale = 0;
    void Update()
    {
        gameObject.transform.position = new Vector2(GameObject.Find("train").transform.position.x, GameObject.Find("train").transform.position.y);
        if (new_scale < scale_max)
        {     
            new_scale += scale_change;
            gameObject.transform.localScale = new Vector3(new_scale, new_scale, 1);
        }
        gameObject.GetComponent<BoxCollider2D>().size = new Vector2(new_scale * ratio, new_scale * ratio/3);
        //Debug.Log(gameObject.GetComponent<BoxCollider2D>().size);
    }
}
