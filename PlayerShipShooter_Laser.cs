using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Ensure that the player GameObject has a child GameObject
// with the corresponding laser script and a Line Renderer component. 
// That "laser" component should be Active.
public class PlayerShipShooter_Laser : MonoBehaviour {
    public float range = 500f;
    public float speedDamage = 20f;
    public AudioClip shotSound;
    public float shotVolume = 0.8f;
    public enum GamePad {Player1, Player2};

    [SerializeField] private GamePad gamePad;
    private Rigidbody rb;
    private LineRenderer laserLine;
    private ParticleSystem particleSystem;
    
    // Use this for initialization
    void Start() {
        rb = gameObject.GetComponent<Rigidbody>();
        laserLine = gameObject.GetComponentInChildren<LineRenderer>();
        laserLine.enabled = false;
		laserLine.SetWidth (.2f, .2f);
        particleSystem = gameObject.GetComponentInChildren<ParticleSystem>();
        var emission = particleSystem.emission;
        emission.enabled = false;
    }

    // Update is called once per frame
    void Update() {
        if (gamePad.ToString() == "Player1") {
            if (Input.GetButtonDown("Fire1_P1")) {
                Fire();
                // Debug.Log("Player1 has shot.");
            }
        }
        if (gamePad.ToString() == "Player2") {
            if (Input.GetButtonDown("Fire1_P2")) {
                Fire();
                // Debug.Log("Player2 has shot.");
            }
        }
    }

    void Fire() {
        // This section is to setup and toggle the line renderer and particle system that creates the visible laser beam.
        Vector3 startPoint = gameObject.transform.position;            
        Vector3 endPoint = startPoint;
        endPoint.z += range;
        laserLine.enabled = true;
        laserLine.SetPosition (0, startPoint);
        laserLine.SetPosition (1, endPoint);
        var emission = particleSystem.emission;
        emission.enabled = true;

        GetComponent<AudioSource>().PlayOneShot(shotSound, shotVolume);

        // This section is to actually perform hit detection using a Raycast.
        RaycastHit hit;
        if (Physics.Raycast(transform.position, new Vector3(0,0,1), out hit, Mathf.Infinity)) {
            if (hit.transform.gameObject.tag == "Hazard") {
                hit.transform.gameObject.SetActive(false);
            }
            if (hit.transform.gameObject.tag == "Player") {
                hit.transform.gameObject.GetComponent<ShipControls>().SustainDamage(speedDamage);
            }
        }
    }
}
