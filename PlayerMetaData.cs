using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerMetaData {
    private static string lastWinner;

    public static string GetLastWinner() {
        return lastWinner;
    }
    public static void SetLastWinner(string newLastWinner) {
        lastWinner = newLastWinner;
    }
}
