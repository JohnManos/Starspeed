using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShipShooter_Projectile : MonoBehaviour {
    public float range = 500f;
    public GameObject muzzleFlash;
    public AudioClip shotSound;
    public float shotVolume;
    public enum GamePad {Player1, Player2};
    //public float speedDamage = 10f;

    [SerializeField] private int shotsPerBurst = 1;  
    [SerializeField] private float burstCooldown = 0.5f;
    [SerializeField] private GamePad gamePad;
    // Ensure that the projectile GameObject has a tag of "Projectile"
    // and the corresponding Projectile script
    [SerializeField] private GameObject projectile;
    
    private Rigidbody rb;
    private ParticleSystem muzzleFlashPS;
    private int burstShotCounter = 0;
    private float burstCooldownTimer = 0f;
    
    // Use this for initialization
    void Start() {
        projectile.SetActive(false);
        rb = gameObject.GetComponent<Rigidbody>();
        muzzleFlash.SetActive(false);
        muzzleFlashPS = muzzleFlash.GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void FixedUpdate() {
        if (burstShotCounter >= shotsPerBurst) {
            burstCooldownTimer += Time.fixedDeltaTime;
            if (burstCooldownTimer >= burstCooldown) {
                burstShotCounter = 0;
                burstCooldownTimer = 0f;
            }
        }      
        if (gamePad.ToString() == "Player1") {
            if (Input.GetButtonDown("Fire1_P1")) {
                if (burstCooldownTimer == 0f) {
                    StartCoroutine(FireSequence());  
                }
            }
        }
        if (gamePad.ToString() == "Player2") {
            if (Input.GetButtonDown("Fire1_P2")) {
                if (burstCooldownTimer == 0f) {
                    StartCoroutine(FireSequence());  
                }
            }
        }
    }

    IEnumerator FireSequence() {
        muzzleFlash.SetActive(true);
        while (burstShotCounter++ < shotsPerBurst) {
            StartCoroutine(Fire());
            yield return new WaitForSecondsRealtime(.1f); // to prevent bullets from spawning simultaneously
        }
        muzzleFlash.SetActive(false);
    }

    IEnumerator Fire() {
        GameObject shot = Instantiate(projectile);
        shot.transform.position = projectile.transform.position;
        shot.SetActive(true);
        float playerSpeed = rb.velocity.z;
        GetComponent<AudioSource>().PlayOneShot(shotSound, shotVolume);
        shot.GetComponent<Projectile>().Launch(playerSpeed);
        yield return null;
    }
}
