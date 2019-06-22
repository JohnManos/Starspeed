using UnityEngine;
using System.Collections;

public class ShipMove_Cinematic : MonoBehaviour {

    public float maxDisplacementY = 5f;
    public GameObject scene;
    public Camera mainCam;

    private Rigidbody rb;
    private Vector3 startPosition;

    void Start() {
        //rb = GetComponent<Rigidbody>();
        startPosition = transform.position;
    }

    void FixedUpdate() {
        transform.position = startPosition + new Vector3(0f, Mathf.Sin(Time.time) * maxDisplacementY, transform.position.z);
        var position = scene.transform.position;
        ++position.z;
        scene.transform.position = position;
        var camPosition = mainCam.transform.position;
        ++camPosition.z;
        mainCam.transform.position = camPosition;
    }
}
