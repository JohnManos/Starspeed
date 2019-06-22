using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceHazard : MonoBehaviour {
    public float speedPenaltyMultiplier = .01f;

    void OnTriggerEnter(Collider playerCollider) {
        if (playerCollider.gameObject.tag == "Player") {
            Vector3 playerVelocity = playerCollider.gameObject.GetComponent<Rigidbody>().velocity;
            playerVelocity.z = playerVelocity.z * speedPenaltyMultiplier;
            playerCollider.gameObject.GetComponent<Rigidbody>().velocity = playerVelocity;
            Destroy(gameObject);
        }
    }
}
