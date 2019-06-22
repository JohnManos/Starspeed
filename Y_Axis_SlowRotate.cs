using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Y_Axis_SlowRotate : MonoBehaviour {

    [SerializeField]
    private bool isclockwise = false;
    [SerializeField]
    private float speedFactor = 4.2f;

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        if (isclockwise) { 
            transform.Rotate(0, -1 * Time.deltaTime * speedFactor, 0);
        }
        else if (!isclockwise) {
            transform.Rotate(0, Time.deltaTime * speedFactor, 0);
        }
    }
}
