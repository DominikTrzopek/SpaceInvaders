using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class gameover : MonoBehaviour
{
    public Text endtext;
    void Update()
    {
        if(GameObject.FindGameObjectsWithTag("UI_HP2").Length == 0 || GameObject.FindGameObjectsWithTag("UI_HP").Length == 0)
        {
            GameObject.Find("train").GetComponent<shooting>().enabled = false;
            GameObject.Find("cannon").GetComponent<cannon>().enabled = false;
            endtext.enabled = true;
        }

    }
}
