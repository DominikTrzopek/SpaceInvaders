using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_shield : MonoBehaviour
{
    public GameObject shield;
    //public Rigidbody2D rbody;
    void Start()
    {
        Instantiate(shield, transform.position, transform.rotation, gameObject.transform);
    }
    
   
}
