using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Y_Axis_SlowRotate : MonoBehaviour {

    public float speed = 4.2f;

    [SerializeField]
    private bool isclockwise = false;

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        if (isclockwise) { 
            transform.Rotate(0, -1 * Time.deltaTime * speed, 0);
        }
        else if (!isclockwise) {
            transform.Rotate(0, Time.deltaTime * speed, 0);
        }
    }
}
