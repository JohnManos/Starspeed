using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipFollowCamera_NoRotate : MonoBehaviour
{
    public GameObject target;
    public float damping = 1;

    private float offset;

    void Start()
    {
        offset = target.transform.position.z - transform.position.z;
    }

    void LateUpdate()
    {
        float currentX = transform.position.x;
        float currentY = transform.position.y;
        float desiredX = target.transform.position.x;
        float desiredY = target.transform.position.y;

        float x = Mathf.Lerp(currentX, desiredX, Time.deltaTime * damping);
        float y = Mathf.Lerp(currentY, desiredY, Time.deltaTime * damping);

        transform.position = new Vector3(x, y, target.transform.position.z - offset);
    }
}