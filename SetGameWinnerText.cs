using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetGameWinnerText : MonoBehaviour {
    public Text winnerText;
    // Start is called before the first frame update
    void Start() {
        if (PlayerMetaData.GetLastWinner() == "Player1") {
            winnerText.text = "Player 1 Wins!"; 
        }
        if (PlayerMetaData.GetLastWinner() == "Player2") {
            winnerText.text = "Player 2 Wins!"; 
        }
    }
}
