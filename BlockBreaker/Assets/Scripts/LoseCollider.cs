using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseCollider : MonoBehaviour {

    private GameStatus game;

    private void Start() {
        game = FindObjectOfType<GameStatus>();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        game.ReloadLevel();
    }

}
