using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody rb;
    public float y_vel;
    private bool jump;
    private bool collide;

    public float grav;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        grav = -9.8f;
        //rb.velocity = new Vector3(4, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        //Physics.gravity = new Vector3(0, grav, 0);
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
    }

    void OnCollisionEnter(Collision col)
    {
        //Don't collide with the ground, only obstacles.
        if(col.gameObject.layer != 7)
        collide = true;

    }

    void OnCollisionExit(Collision col)
    {
        if(col.gameObject.layer != 7)
        collide = false;
    }
}