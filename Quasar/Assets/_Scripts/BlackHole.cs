using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHole : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        pos.x += 4 * Time.deltaTime;
        transform.position = pos;

    }

    void OnCollisionStay(Collision col)
    {
        if(col.gameObject.name == "Player")
        {
            Destroy(col.gameObject);
            Quasar.Respawn();
        }
    }
}
