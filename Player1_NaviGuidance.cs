using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player1_NaviGuidance : MonoBehaviour {

    public GameObject panel;
    public GameObject arrowSprite;
    public GameObject playerShip;
    public GameObject oppShip;

    private GameObject arrowSpriteX;
    private GameObject arrowSpriteY;
    private RectTransform xArrowTransform;
    private RectTransform yArrowTransform;
    private RectTransform panelTransform;
    // private Transform shipTransform;

    // Start is called before the first frame update
    void Start() {
        // Sprite begins deactive,
        // and is cloned so that there is a separate one for the X and Y axes,
        // so that there can be simultaneous X and Y guidance.
        arrowSprite.SetActive(false);
        arrowSpriteX = Instantiate(arrowSprite, transform.parent.transform);
        arrowSpriteY = Instantiate(arrowSprite, transform.parent.transform);
        
        xArrowTransform = arrowSpriteX.GetComponent<RectTransform>();
        yArrowTransform = arrowSpriteY.GetComponent<RectTransform>();
        // shipTransform = otherShip.transform;

        panelTransform = gameObject.GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update() {
        float playerPositionX = playerShip.transform.position.x;
        float playerPositionY = playerShip.transform.position.y;

        float oppPositionX = oppShip.transform.position.x;
        float oppPositionY = oppShip.transform.position.y;

        float arrowPositionXMin = panelTransform.anchoredPosition.x - panelTransform.rect.width*panelTransform.localScale.x/2;
        float arrowPositionXMax = panelTransform.anchoredPosition.x + panelTransform.rect.width*panelTransform.localScale.x/2;
        float arrowPositionYMin = panelTransform.anchoredPosition.y - panelTransform.rect.height*panelTransform.localScale.y/2;
        float arrowPositionYMax = panelTransform.anchoredPosition.y + panelTransform.rect.height*panelTransform.localScale.y/2;

        // Opponent is to the left
        if (playerPositionX > oppPositionX + 3f) {
            xArrowTransform.anchoredPosition = new Vector3(arrowPositionXMin, panelTransform.anchoredPosition.y, 0);
            xArrowTransform.rotation = Quaternion.Euler(0, 0, 0);
            arrowSpriteX.SetActive(true);
        }
        // Opponent is to the right
        else if (playerPositionX < oppPositionX - 3f) {
            xArrowTransform.anchoredPosition = new Vector3(arrowPositionXMax, panelTransform.anchoredPosition.y, 0);
            xArrowTransform.rotation = Quaternion.Euler(0 , 0, 180);
            arrowSpriteX.SetActive(true);
        }
        else {
            arrowSpriteX.SetActive(false);
        }
        // Opponent is below
        if (playerPositionY > oppPositionY + 3f) {
            yArrowTransform.anchoredPosition = new Vector3(panelTransform.anchoredPosition.x, arrowPositionYMin, 0);
            yArrowTransform.rotation = Quaternion.Euler(0, 0, 90);
            arrowSpriteY.SetActive(true);
        }
        // Opponent is above
        else if (playerPositionY < oppPositionY - 3f) {
            yArrowTransform.anchoredPosition = new Vector3(panelTransform.anchoredPosition.x, arrowPositionYMax, 0);
            yArrowTransform.rotation = Quaternion.Euler(0, 0, -90);
            arrowSpriteY.SetActive(true);
        }
        else {
            arrowSpriteY.SetActive(false);
        }

        if (playerShip.transform.position.z > oppShip.transform.position.z) {
            panel.GetComponent<Image>().color = new Color32(255,103,0,75);
        }
        else {
            panel.GetComponent<Image>().color = new Color32(0,128,33,85);
        }

        xArrowTransform.ForceUpdateRectTransforms();
        yArrowTransform.ForceUpdateRectTransforms();
    }
}
