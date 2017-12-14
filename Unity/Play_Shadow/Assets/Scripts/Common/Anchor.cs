using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anchor : MonoBehaviour
{
    public float xPos = 0.9f;
    public float yPos = 0.9f;
    void Start()
    {
        // float height = Screen.height;
        // float width = Screen.width;
        // transform.localPosition = new Vector3(width / 2 - xDiff, height / 2 - yDiff, 0);
        transform.position = Camera.main.ViewportToWorldPoint(new Vector3(xPos, yPos, 100));
    }
}
