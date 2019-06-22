using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {    
    public float speedDamage = 25f;

    [SerializeField] private float lifeTime = 2.0f;
    [SerializeField] private float relativeVelocity = 1000f;

    private int lifeTimeFrames = 0;
    private int timeLived = 0;
    private float speed = 0f;

	void Start () {       
        lifeTimeFrames = (int)(lifeTime / Time.fixedDeltaTime);
        Debug.Log("Shot spawned.");
	}

	void FixedUpdate () {
		if (timeLived < lifeTimeFrames) {
            timeLived++;
        }
        else {
            Destroy(gameObject);
        }
	}

    void OnCollisionEnter(Collision collision) {
        Debug.Log("Collision object name: " + collision.gameObject.name);
        if (collision.transform.gameObject.tag == "Hazard") {
            collision.transform.gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else if (collision.transform.gameObject.tag == "Player") {
            collision.transform.gameObject.GetComponent<ShipControls>().SustainDamage(speedDamage);
            Destroy(gameObject);
        }
    }

    public void Launch(float emitVelocity) {
        Vector3 velocity = gameObject.GetComponent<Rigidbody>().velocity;
        speed = emitVelocity + relativeVelocity;
        velocity.z = speed;
        gameObject.GetComponent<Rigidbody>().velocity = velocity;
        // Debug.Log("Projectile absolute z velocity is: " + gameObject.GetComponent<Rigidbody>().velocity.z);
    }
}
