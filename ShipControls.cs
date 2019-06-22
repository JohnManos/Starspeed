using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary {
    public float xMin, xMax, yMin, yMax;
}

public enum GamePad {Player1, Player2}

public class ShipControls : MonoBehaviour {
    // Ensure that the project settings contains
    // input axes for joystick 1 named Horizontal_P1 and Vertical_P1,
    // and input axes for joystick 2 named Horizontal_P2 and Vertical_P2
    public float xAndYSpeed = 10f;
    public float thrust = 2f;
    public float maxSpeed = 500f;
    public float boostForce = 100f;
    public float boostCooldown = 10f;
    public GameObject contrail;
    public AudioClip boostSound;
    public Boundary boundary;

    [SerializeField] private GamePad gamePad;
    private Rigidbody rb;
    private Component[] contrailPS;
    private float moveHorizontal = 0f;
    private float moveVertical = 0f;
    private float currentVelocity = 0f;
    private float boostCooldownTimer = 0f;

    public void SustainDamage(float speedPenalty) {
        if (GetComponent<Rigidbody>().velocity.z - speedPenalty >= 0) {
            rb.AddForce(0, 0, -speedPenalty, ForceMode.VelocityChange);
        }
        else {
            rb.AddForce(0, 0, -currentVelocity, ForceMode.VelocityChange);
        }
    }

    public GamePad GetGamePad() {
        return gamePad;
    }

    public float GetVelocity() {
        return currentVelocity;
    }

    void Start() {
        rb = GetComponent<Rigidbody>();
        var i = 0;
        contrailPS = contrail.GetComponentsInChildren<ParticleSystem>();
        // contrail.SetActive(false);
    }

    void FixedUpdate() {
        Vector3 rbPosition = rb.position;
        currentVelocity = rb.velocity.z;
        boostCooldownTimer += Time.fixedDeltaTime;

        // If this is Player1, retrieve Player1 movement input
        if (gamePad.ToString() == "Player1") {
            moveHorizontal = Input.GetAxis("Horizontal_P1");
            moveVertical = Input.GetAxis("Vertical_P1");

            if (!IsLeavingBoundariesX()) {
                var x = moveHorizontal * Time.deltaTime * xAndYSpeed;
                rbPosition.x = transform.position.x + x; 
                transform.position = rbPosition;
            }

            if (!IsLeavingBoundariesY()) {
                var y = moveVertical * Time.deltaTime * xAndYSpeed;
                rbPosition.y = transform.position.y + y; 
                transform.position = rbPosition;           
            }    

            if (Input.GetButtonDown("Boost_P1") && boostCooldownTimer >= boostCooldown) {
                Boost();
                Debug.Log("P1 boosted.");
            }       
        }

        // If this is Player2, retrieve Player2 movement input
        if (gamePad.ToString() == "Player2") {
            moveHorizontal = Input.GetAxis("Horizontal_P2");
            moveVertical = Input.GetAxis("Vertical_P2");

            if (!IsLeavingBoundariesX()) {
                var x = moveHorizontal * Time.deltaTime * xAndYSpeed;
                rbPosition.x = transform.position.x + x; 
                transform.position = rbPosition;
            }

            if (!IsLeavingBoundariesY()) {
                var y = moveVertical * Time.deltaTime * xAndYSpeed;
                rbPosition.y = transform.position.y + y; 
                transform.position = rbPosition;           
            } 

            if (Input.GetButtonDown("Boost_P2") && boostCooldownTimer >= boostCooldown) {
                Boost();
                Debug.Log("P2 boosted.");
            } 
        }           
        
        if (rb.velocity.z < maxSpeed) {
            rb.AddRelativeForce(transform.forward * thrust);
        }
        else {
            Debug.Log("Reached maxspeed.");
        }
        // GetComponent<Rigidbody>().position = new Vector3
        //     (
        //         Mathf.Clamp(GetComponent<Rigidbody>().position.x, boundary.xMin, boundary.xMax),
        //         Mathf.Clamp(GetComponent<Rigidbody>().position.y, boundary.yMin, boundary.yMax),
        //         0.0f
        //         );
    }

    // bool IsWithinBoundaries() {
    //     // Check if x position is outside x boundaries
    //     if (transform.position.x < boundary.xMin || transform.position.x < boundary.xMax) {
    //         return false;
    //     }
    //     // Check if y position is outside y boundaries
    //     else if (transform.position.y < boundary.yMin || transform.position.y < boundary.yMax) {
    //         return false;
    //     }        
    //     // Else x and y, and therefore also the ship, are within boundaries
    //     else {
    //         return true;
    //     }
    // }

    bool IsLeavingBoundariesX() {
        // If position has reached left boundary and player is moving left
        if (transform.position.x <= boundary.xMin && moveHorizontal < 0) {
            return true;
        }
        // If position has reached right boundary and player is moving right
        else if (transform.position.x >= boundary.xMax && moveHorizontal > 0) {
            return true;
        }
        // Otherwise, player is not leaving the x bounds
        else {
            return false;
        }
    }

    bool IsLeavingBoundariesY() {
        // If position has reached lower boundary and player is moving down
        if (transform.position.y <= boundary.yMin && moveVertical < 0) {
            return true;
        }
        // If position has reached upper boundary and player is moving up
        else if (transform.position.y >= boundary.yMax && moveVertical > 0) {
            return true;
        }
        // Otherwise, player is not leaving the y bounds
        else {
            return false;
        }
    }

    void Boost() {
        rb.AddForce(0, 0, boostForce, ForceMode.Force);
        GetComponent<AudioSource>().PlayOneShot(boostSound);
        StartCoroutine(BoostEffect());
        // contrail.transform.position = transform.position - new Vector3(0, 0, 2.5f);
        // contrail.SetActive(true);
        boostCooldownTimer = 0f;
    }

    IEnumerator BoostEffect() {
        foreach(ParticleSystem ps in contrailPS) {
            var main = ps.main;
            main.startSize = 1f;
        }
        yield return new WaitForSeconds(2f);
        foreach(ParticleSystem ps in contrailPS) {
            var main = ps.main;
            main.startSize = .25f;
        }
    }
}
