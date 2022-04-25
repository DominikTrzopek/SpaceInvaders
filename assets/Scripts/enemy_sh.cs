using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class enemy_sh : MonoBehaviour
{
    public float timer, t;
    public GameObject prefab;
    void Update()
    {
        timer -= 1 * Time.deltaTime;
        if (timer <= 0)
        {
            Instantiate(prefab, transform.position, transform.rotation);
            timer = Random.Range(t - 1, t + 2);
        }
        //Debug.Log(timer);
    }
}
