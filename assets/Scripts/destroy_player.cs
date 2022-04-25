using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroy_player : MonoBehaviour
{
    public int HP;
    //public float source_x, source_y;
    public GameObject prefab, fire, background1, background2, hit1, hit2; 
    //public float space;
    Vector2 source;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "bullet" && HP > 0)
        {
            HP -= 1;
            Instantiate(hit1, background1.transform.position, background1.transform.rotation);
            Instantiate(hit2, background2.transform.position, background2.transform.rotation);
            if (GameObject.Find("shield(Clone)") != null)
                Destroy(GameObject.Find("shield(Clone)"));
        }

    }
    void Update()
    {
        //source = new Vector2(source_x, source_y);
        if (HP <= 0)
        {
            Instantiate(fire, transform.position, transform.rotation);
        }
        //Debug.Log(HP);
        var num = GameObject.FindGameObjectsWithTag("UI_HP");
        /*if (num_player.Length < HP)
        {
            source_x += space;
            source = new Vector2(source_x, source_y);
            Instantiate(prefab, source, transform.rotation);
        }*/
        if(num.Length > HP)
        {
            Destroy(GameObject.FindGameObjectWithTag("UI_HP"));
        }

    }
}
