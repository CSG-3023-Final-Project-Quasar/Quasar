using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateBlackHole : MonoBehaviour {

    Vector3 rotationVector;

    // Start is called before the first frame update
    void Start() {
        rotationVector = transform.rotation.eulerAngles;
    }

    // Update is called once per frame
    void Update() {
        rotationVector.x += 0.05f;
       
        transform.rotation = Quaternion.Euler(rotationVector);
    }
}
