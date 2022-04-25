using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class background_ship : MonoBehaviour
{
    public GameObject prefab;
    public float density;
    float timebetween = 1, spawn_y;
    Vector3 spawn;
    int rand;
    void Update()
    {
        spawn_y = Random.Range(0, 2);
        rand = (int)Random.Range(0, 2);
        //Debug.Log(rand);
        if(rand == 0 && timebetween < 0)
        {
            spawn = new Vector3(-30, spawn_y, 0);
            Instantiate(prefab, spawn, transform.rotation);
            timebetween = density;
        }
        timebetween -= Time.deltaTime;
        if (rand == 1 && timebetween < 0)
        {
            Quaternion rot = new Quaternion(0, 180, 0, 0);
            spawn = new Vector3(30, spawn_y, 0);
            Instantiate(prefab, spawn, rot);
            timebetween = density;
        }

    }
}
