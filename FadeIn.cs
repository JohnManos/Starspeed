using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour {
    
    public Text text;
    public float timeDampening = 0.2f;

    private Color textColor;

    // Start is called before the first frame update
    void Start() {
        textColor = text.color;
        textColor.a = 0f/255f;
        text.color = textColor;
    }

    // Update is called once per frame
    void Update() {
        float newAlpha;
        newAlpha = Mathf.Lerp(0f, 255f, Time.time * timeDampening);
        textColor.a = newAlpha/255f;
        text.color = textColor;
    }
}
