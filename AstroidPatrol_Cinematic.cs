using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstroidPatrol_Cinematic : MonoBehaviour {
    public GameObject scene;
    public float zMin = -20f;

    private float zMax;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start() {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(0, 0, -1*Random.Range(10, 30), ForceMode.VelocityChange);
        zMax = transform.localPosition.z;
    }

    // Update is called once per frame
    void FixedUpdate() {
        Vector3 position = transform.position;
        if (transform.localPosition.z <= zMin) {
            position.z = zMax;
            transform.localPosition = position;
        }
    }
}
