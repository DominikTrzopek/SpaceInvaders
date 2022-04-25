using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooting : MonoBehaviour
{
    public GameObject prefab, shield, prefab2, prefab3;
    public float treshold, energy_cost, energy_regen, dash_cost, dash_distance, shield_cost, speed;
    float current_energy = 0, rduration = 0;
    public Rigidbody2D train;
    public GameObject pivot, shadow;


    public float x_UIscale;
    public float y_UIscale;
    public float z_UIscale;
    void Update()
    {
        var shooting_border = GameObject.Find("cannon").transform.rotation.z;
        if (Input.GetMouseButtonDown(0) && (treshold - energy_cost > current_energy) && (shooting_border < -0.05) && (shooting_border > -0.999))
        {
            Instantiate(prefab, pivot.transform.position, pivot.transform.rotation);
            Instantiate(prefab2, transform.position, pivot.transform.rotation);
            Instantiate(prefab3, pivot.transform.position, pivot.transform.rotation);
            current_energy += energy_cost;
        }
        if (current_energy > 0)
            current_energy += -energy_regen * Time.deltaTime;

        var posx = train.transform.position.x;
        var posy = train.transform.position.y;
        if (Input.GetKey("left shift") && Input.GetKey("a") && (treshold - dash_cost) > current_energy && rduration < 0)
        {
            //train.AddForce(-transform.right * dash_distance, ForceMode2D.Force);
            train.transform.position = new Vector2(posx - dash_distance, posy);
            current_energy += dash_cost;
            rduration = 1;
            Instantiate(shadow, transform.position, transform.rotation);
            GameObject.Find("shadow(Clone)").GetComponent<Transform>().rotation = new Quaternion(0, 0, 0, 0);
        }
        if (Input.GetKey("left shift") && Input.GetKey("d") && (treshold - dash_cost) > current_energy && rduration < 0)
        {
            //train.AddForce(transform.right * dash_distance, ForceMode2D.Impulse);
            GameObject.Find("train").transform.position = new Vector2(posx + dash_distance, posy);
            current_energy += dash_cost;
            rduration = 1;
            Instantiate(shadow, transform.position, transform.rotation);
            GameObject.Find("shadow(Clone)").GetComponent<Transform>().rotation = new Quaternion(0, 180, 0, 0);
        }
        rduration -= Time.deltaTime;
        // Debug.Log(rduration);

        var shield_pos = new Vector2(train.transform.position.x, train.transform.position.y);
        var shield_rot = train.transform.rotation;
        if (Input.GetMouseButtonDown(1) && (treshold > current_energy))
            Instantiate(shield, shield_pos, shield_rot);
        else if (Input.GetMouseButtonUp(1) || (treshold - shield_cost) < current_energy )
            Destroy(GameObject.Find("shield(Clone)"));
        if(GameObject.Find("shield(Clone)") != null && (treshold > current_energy))
            current_energy += shield_cost;

        float y_new = (float)(y_UIscale * current_energy * 0.01);
        Vector3 scale = new Vector3(x_UIscale, y_new, z_UIscale);
        GameObject.Find("HeatUI").transform.localScale = scale;

        if (Input.GetKey("a"))
            train.AddForce(-transform.right * speed);
        if (Input.GetKey("d"))
            train.AddForce(transform.right * speed);
        train.GetComponent<Rigidbody2D>().velocity = new Vector2(train.GetComponent<Rigidbody2D>().velocity.x, 0);
    }

}
