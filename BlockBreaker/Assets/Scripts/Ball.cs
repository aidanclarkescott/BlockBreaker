using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    #region Config Params
    [SerializeField] Paddle paddle1;
    [SerializeField] float xPush = 2f;
    [SerializeField] float yPush = 15f;
    [SerializeField] AudioClip[] collisionSounds;
    [SerializeField] float randomFactor = 0.2f;
    Rigidbody2D rigidbody2D;
    #endregion

    #region State
    Vector2 paddleToBallVector;
    bool hasStarted = false;
    #endregion

    #region Cached Component References
    AudioSource myAudioSource;
    #endregion

    // Start is called before the first frame update
    void Start() {
        paddleToBallVector = transform.position - paddle1.transform.position;
        myAudioSource = GetComponent<AudioSource>();
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() {
        if (!hasStarted) {
            LockBallToPaddle();
            LaunchOnClick();
        }
    }

    private void LaunchOnClick() {
        if (Input.GetMouseButtonDown(0)) {
            hasStarted = true;
            rigidbody2D.velocity = new Vector2(xPush, yPush);
        }
    }

    private void LockBallToPaddle() {
        Vector2 paddlePosition = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        transform.position = paddlePosition + paddleToBallVector;
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        Vector2 velocityTweak = new Vector2(Random.Range(0f, randomFactor), Random.Range(0f, randomFactor));

        if (hasStarted) {
            myAudioSource.PlayOneShot(collisionSounds[UnityEngine.Random.Range(0, collisionSounds.Length)]);
            rigidbody2D.velocity += velocityTweak;
        }
    }
}
