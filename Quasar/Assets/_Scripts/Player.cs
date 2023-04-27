using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody rb;
    public float y_vel;
    private bool jump;
    private bool collide;

    private bool redOn;

    public float grav;
    public Material blueMat;
    public Material redMat;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        grav = -9.8f;
        redOn = false;

        Physics.IgnoreLayerCollision(0, 11, true);
        Physics.IgnoreLayerCollision(0, 12, false);
        redMat.SetColor("_Color", new Color(255, 0, 0, 0));
        blueMat.SetColor("_Color", new Color(0, 0, 255, 255));
    }

    // Update is called once per frame
    void Update()
    {
        rb.WakeUp();
        if (!collide)
        {
            Vector3 pos = transform.position;
            pos.x += 4 * Time.deltaTime;
            transform.position = pos;
        }

        if (Input.GetKeyDown(KeyCode.Space) && rb.velocity.y == 0)
        {
            if(Physics.gravity.y < 0) rb.velocity = new Vector3(rb.velocity.x, 7, 0);
            if(Physics.gravity.y > 0) rb.velocity = new Vector3(rb.velocity.x, -7, 0);
        }

        if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (redOn)
            {
                Physics.IgnoreLayerCollision(0, 11, true);
                Physics.IgnoreLayerCollision(0, 12, false);
                redOn = false;
                redMat.SetColor("_Color", new Color(255, 0, 0, 0));
                blueMat.SetColor("_Color", new Color(0, 0, 255, 255));
            }
            else
            {
                Physics.IgnoreLayerCollision(0, 11, false);
                Physics.IgnoreLayerCollision(0, 12, true);
                redOn = true;
                redMat.SetColor("_Color", new Color(255, 0, 0, 255));
                blueMat.SetColor("_Color", new Color(0, 0, 255, 0));
            }
        }
    }

    void OnCollisionEnter(Collision col)
    {
        //Don't stop on colliding with the ground, only obstacles.
        if (col.gameObject.tag == "Platform")
        collide = true;

        if (col.gameObject.tag == "Goal")
        Quasar.ChangeScene("End");
    }


    void OnCollisionExit(Collision col)
    {
        if(col.gameObject.tag == "Platform")
        collide = false;
    }
}