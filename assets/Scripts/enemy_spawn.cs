using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_spawn : MonoBehaviour
{
    public float timer, randomtimer;
    public GameObject enemy_yellow, enemy_red, enemy_blue;
    int whichenemy;
    void Update()
    {
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            whichenemy = Random.Range(0, 5);
            if (whichenemy > 0 && whichenemy < 3)
                Instantiate(enemy_yellow, transform.position, transform.rotation);
            else if (whichenemy >= 3 && whichenemy < 4)
                Instantiate(enemy_red, transform.position, transform.rotation);
            else if (whichenemy >= 4 && whichenemy < 5)
                Instantiate(enemy_blue, transform.position, transform.rotation);
            if(randomtimer > 4.2f)
                randomtimer -= 0.05f;
            timer = Random.Range(randomtimer - 3, randomtimer + 3);
        }
        Debug.Log(randomtimer);
     
    }
}
