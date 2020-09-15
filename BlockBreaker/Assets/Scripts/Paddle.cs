using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {
    [SerializeField] private float screenWidthInUnits = 16;
    private float minX = 1f;
    private float maxX = 15f;
    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        float horizontalPos = Mathf.Clamp(Input.mousePosition.x / Screen.width * screenWidthInUnits, minX, maxX);
        Vector2 paddlePos = new Vector2(horizontalPos, transform.position.y);
        transform.position = paddlePos;

    }
}
