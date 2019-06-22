using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpponentFollowCamera_NoRotate : MonoBehaviour {
    public GameObject target;
    public GameObject follower;

    private float offset;

    void Start() {
        offset = target.transform.position.z - transform.position.z;
    }

    void LateUpdate() {
        float currentX = follower.transform.position.x;
        float currentY = follower.transform.position.y;
        // Debug.Log("Target position z: " + target.transform.position.z);
        // Debug.Log("Follower x and y are: " + currentX + " " + currentY);

        transform.position = new Vector3(currentX, currentY, target.transform.position.z - offset);
    }
}