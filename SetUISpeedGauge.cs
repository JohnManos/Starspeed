using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetUISpeedGauge : MonoBehaviour {
    public Text speedTextBox;
    public Text distanceTextBox;
    public GameObject player;

    // Update is called once per frame
    void Update() {
        speedTextBox.text = "Speed: " + player.GetComponent<ShipControls>().GetVelocity().ToString();
        distanceTextBox.text = "Distance: " + player.GetComponent<Rigidbody>().position.z.ToString("F0");
    }
}
