using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity_Cube : MonoBehaviour
{
    public float grav;
    
    void OnTriggerEnter(Collider col)
    {
        Physics.gravity = new Vector3(0, grav, 0);

        this.GetComponent<Renderer>().material.SetColor("_Color", new Color(0f, 0f, 0f, 0f));
    }

    void OnTriggerExit(Collider col)
    {
        Physics.gravity = new Vector3(0, -9.8f, 0);
    }
}
