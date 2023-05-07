using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHole : MonoBehaviour
{
    private GameObject go;
    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        pos.x += 4 * Time.deltaTime; //Set movement for the black hole
        transform.position = pos;

    }

    void OnCollisionStay(Collision col)
    {
        if(col.gameObject.name == "Player" && go != col.gameObject)
        {
            go = col.gameObject; //Ensures only one death
            Quasar.Respawn();
            DeathCount.UpdateScore(); //Increment deaths
            TotalDeaths.UPDATE_SCORE();
        }
    }
}
