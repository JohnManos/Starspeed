using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstroidPatrol : MonoBehaviour {
    [SerializeField] private float xMax = 50f;
    [SerializeField] private bool goRight = true;
    private float xMin;

    public float GetXMax() {
        return xMax;
    }
    public bool IsGoingRight() {
        return goRight;
    }

    // Start is called before the first frame update
    void Start() {
        if (goRight) {
            GetComponent<Rigidbody>().AddForce(Random.Range(10, 30), 0, 0, ForceMode.VelocityChange);
        }
        else {
            GetComponent<Rigidbody>().AddForce(-1*Random.Range(10, 30), 0, 0, ForceMode.VelocityChange);
        }
        xMin = transform.position.x;
    }

    // Update is called once per frame
    void FixedUpdate() {
        // Vector3 rbPosition = GetComponent<Rigidbody>().position;
        if (goRight && transform.position.x >= xMax) {
            Instantiate(gameObject, new Vector3(xMin, transform.position.y, transform.position.z), transform.rotation);
            Destroy(gameObject);
            // rbPosition.x = xMin;
            // transform.position = rbPosition;
        }
        else if (!goRight && transform.position.x <= xMax) {
            Instantiate(gameObject, new Vector3(xMin, transform.position.y, transform.position.z), transform.rotation);
            Destroy(gameObject);
            // rbPosition.x = xMin;
            // transform.position = rbPosition;
        }
    }
}
