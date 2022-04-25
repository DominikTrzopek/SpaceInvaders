using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class score : MonoBehaviour
{
    int current_score = 0;
    public Text scoretext;
    int sum = 0;
    void FixedUpdate()
    {
        var num = GameObject.FindGameObjectsWithTag("enemy");
        var num2 = GameObject.FindGameObjectsWithTag("en1");
        var num3 = GameObject.FindGameObjectsWithTag("en2");
        if(sum > num.Length + num2.Length + num3.Length)
            current_score += 1;
        sum = num.Length + num2.Length + num3.Length;
        scoretext.text = current_score.ToString();
    }
}
