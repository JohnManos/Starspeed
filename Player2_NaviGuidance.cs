using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2_NaviGuidance : MonoBehaviour {

    public GameObject arrowSprite;
    public GameObject playerShip;
    public GameObject oppShip;

    private GameObject arrowSpriteX;
    private GameObject arrowSpriteY;
    private RectTransform arrowTransformX;
    private RectTransform arrowTransformY;
    // private Transform shipTransform;

    // Start is called before the first frame update
    void Start() {
        // Sprite begins deactive,
        // and is cloned so that there is a separate one for the X and Y axes,
        // so that there can be simultaneous X and Y guidance.
        arrowSprite.SetActive(false);
        arrowSpriteX = Instantiate(arrowSprite, transform.parent.transform);
        arrowSpriteY = Instantiate(arrowSprite, transform.parent.transform);
        
        arrowTransformX = arrowSpriteX.GetComponent<RectTransform>();
        arrowTransformY = arrowSpriteY.GetComponent<RectTransform>();
        // shipTransform = otherShip.transform;
    }

    // Update is called once per frame
    void Update() {
        float playerPositionX = playerShip.transform.position.x;
        float playerPositionY = playerShip.transform.position.y;

        float oppPositionX = oppShip.transform.position.x;
        float oppPositionY = oppShip.transform.position.y;

        // Opponent is to the left
        if (playerPositionX > oppPositionX + 3f) {
            arrowTransformX.anchoredPosition = new Vector3(630, 400, 0);
            arrowTransformX.rotation = Quaternion.Euler(0, 0, 0);
            arrowSpriteX.SetActive(true);
        }
        // Opponent is to the right
        else if (playerPositionX < oppPositionX - 3f) {
            arrowTransformX.anchoredPosition = new Vector3(890, 400, 0);
            arrowTransformX.rotation = Quaternion.Euler(0 , 0, 180);
            arrowSpriteX.SetActive(true);
        }
        else {
            arrowSpriteX.SetActive(false);
        }
        // Opponent is below
        if (playerPositionY > oppPositionY + 3f) {
            arrowTransformY.anchoredPosition = new Vector3(760, 270, 0);
            arrowTransformY.rotation = Quaternion.Euler(0, 0, 90);
            arrowSpriteY.SetActive(true);
        }
        // Opponent is above
        else if (playerPositionY < oppPositionY - 3f) {
            arrowTransformY.anchoredPosition = new Vector3(760, 530, 0);
            arrowTransformY.rotation = Quaternion.Euler(0, 0, -90);
            arrowSpriteY.SetActive(true);
        }
        else {
            arrowSpriteY.SetActive(false);
        }

        arrowTransformX.ForceUpdateRectTransforms();
        arrowTransformY.ForceUpdateRectTransforms();
    }
}
