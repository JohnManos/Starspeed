using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipSpeedBoost : MonoBehaviour {
    public float velocityBoost = 20f;
    public float maxBoostedSpeed = 110f;
    public AudioClip sound;
    public float soundVolume = 1f;

    void OnTriggerEnter(Collider playerCollider) {
        GetComponent<AudioSource>().PlayOneShot(sound, soundVolume);
        if (playerCollider.gameObject.GetComponent<Rigidbody>().velocity.z + velocityBoost <= 110f) {
            playerCollider.gameObject.GetComponent<Rigidbody>()
            .AddForce(0, 0, velocityBoost, ForceMode.VelocityChange);
            // Debug.Log("Player z velocity is currenty: " + playerCollider.gameObject.GetComponent<Rigidbody>().velocity.z);
        }
        else {
            Vector3 velocity = playerCollider.gameObject.GetComponent<Rigidbody>().velocity;
            velocity.z = maxBoostedSpeed;
            playerCollider.gameObject.GetComponent<Rigidbody>().velocity = velocity;
        }
    }
}
