using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {
    [SerializeField] private float screenWidthInUnits = 16;
    private float minX = 1f;
    private float maxX = 15f;
    private GameStatus gameStatus;
    private Ball ball;

    // Start is called before the first frame update
    void Start() {
        gameStatus = FindObjectOfType<GameStatus>();
        ball = FindObjectOfType<Ball>();
    }

    // Update is called once per frame
    void Update() {
        Vector2 paddlePos = new Vector2(Mathf.Clamp(GetXPos(), minX, maxX), transform.position.y);
        transform.position = paddlePos;

    }

    private float GetXPos() {
        if (gameStatus.IsAutoPlayEnabled())
            return ball.transform.position.x;
        else
            return Input.mousePosition.x / Screen.width * screenWidthInUnits;

    }
}
