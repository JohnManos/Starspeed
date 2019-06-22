using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour {
    void OnTriggerEnter(Collider collider) {
        if (collider.gameObject.GetComponent<ShipControls>().GetGamePad().ToString() == "Player1") {
            PlayerMetaData.SetLastWinner("Player1");
        }
        if (collider.gameObject.GetComponent<ShipControls>().GetGamePad().ToString() == "Player2") {
            PlayerMetaData.SetLastWinner("Player2");
        }
        SceneManager.LoadScene(2);
    }
}
