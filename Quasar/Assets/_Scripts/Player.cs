using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody rb;
    public float y_vel;
    private bool jump;
<<<<<<< Updated upstream
=======
    private bool collide;

    //Red on is default.
    private bool redOn;

    public float grav;
>>>>>>> Stashed changes
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
<<<<<<< Updated upstream
        rb.velocity = new Vector3(4, 0, 0);
=======
        grav = -9.8f;
        redOn = false;
>>>>>>> Stashed changes
    }

    // Update is called once per frame
    void Update()
    {
<<<<<<< Updated upstream
        y_vel = rb.velocity.y;
        rb.velocity = new Vector3(4, y_vel, 0);

        if (Input.GetKeyDown(KeyCode.Space)) rb.velocity = new Vector3(4, 7, 0);
=======
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
                Physics.IgnoreLayerCollision(0, 11, false);
                Physics.IgnoreLayerCollision(0, 12, true);
                redOn = false;
            }
            else
            {
                Physics.IgnoreLayerCollision(0, 11, true);
                Physics.IgnoreLayerCollision(0, 12, false);
                redOn = true;
            }
        }
    }

    void OnCollisionEnter(Collision col)
    {
        //Don't collide with the ground, only obstacles.
        if (col.gameObject.layer != 7)
        collide = true;
    }

    void OnCollisionExit(Collision col)
    {
        if(col.gameObject.layer != 7)
        collide = false;
>>>>>>> Stashed changes
    }
}