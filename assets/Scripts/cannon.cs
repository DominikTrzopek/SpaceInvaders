using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cannon : MonoBehaviour
{
    const double border_right = -0.999;
    const double border_left = 0;
    void FixedUpdate()
    {
        var mark = GameObject.Find("cel").transform.position.x; 
        var pos = GameObject.Find("train").transform.position; 
        double rot = GameObject.Find("cannon").transform.rotation.z; 
        double rot1 = GameObject.Find("cannon").transform.rotation.x; 
       
        double Yp = GameObject.Find("pivot").transform.position.y;
        double Xp = GameObject.Find("pivot").transform.position.x;
        double yd = GameObject.Find("cannon").transform.position.y;
        double xd = GameObject.Find("cannon").transform.position.x;
        double yc = GameObject.Find("cel").transform.position.y;
        double xc = GameObject.Find("cel").transform.position.x;
        if (((Yp-yd)*(xc-xd) - (yc-yd)*(Xp-xd) > 0.1f) && (rot <= border_left && rot > border_right))
            gameObject.transform.RotateAround(pos, Vector3.back, 90 * Time.deltaTime);
        else if (((Yp - yd) * (xc - xd) - (yc - yd) * (Xp - xd) < 0.1f) && (rot <= border_left && rot > border_right))
            gameObject.transform.RotateAround(pos, Vector3.forward, 90 * Time.deltaTime);
        else if (rot > 0 && rot < 0.3)
            gameObject.transform.RotateAround(pos, Vector3.back, 5 * Time.deltaTime);
        else if (rot >= -1 && rot < 0.8f)
            gameObject.transform.RotateAround(pos, Vector3.forward, 5 * Time.deltaTime);
        // Debug.Log(rot);
    }
}
