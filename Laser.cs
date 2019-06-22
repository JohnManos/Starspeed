using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour {
    public float lifetime = .1f;

    private float timer = 0f;

    // Start is called before the first frame update
    void Start() {
    }

    // Update is called once per frame
    void Update() {
        timer += Time.deltaTime;
        if (timer >= lifetime) {
            // Since the laser beam is entirely for show 
            // (we use an instant Raycast in PlayerShipShooter_Laser.cs to actually detect hits),
            // we simply toggle the laser's renderer and particle system off at the end of its lifetime. 
            gameObject.GetComponent<LineRenderer>().enabled = false;
            var emission = gameObject.GetComponent<ParticleSystem>().emission;
            emission.enabled = false;
        }
    }
}
