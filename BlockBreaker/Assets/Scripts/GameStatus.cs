using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameStatus : MonoBehaviour {

    #region Config Params
    [Range(0.1f, 10f)] [SerializeField] float gameSpeed = 1f;
    [SerializeField] int pointsPerBlockDestroyed = 10;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] bool isAutoPlayEnabled;
    SceneLoader loader;
    #endregion

    #region State Variables
    [SerializeField] int currentScore = 0;
    [SerializeField] int currentLevelScore = 0;
    #endregion

    private void Awake() {
        int gameStatusCount = FindObjectsOfType<GameStatus>().Length;
        if (gameStatusCount > 1) {
            gameObject.SetActive(false);
            Destroy(gameObject);
        } else {
            DontDestroyOnLoad(gameObject);
        }

    }
    // Start is called before the first frame update
    void Start() {
        scoreText.text = currentScore.ToString();
        loader = FindObjectOfType<SceneLoader>();
    }

    // Update is called once per frame
    void Update() {
        Time.timeScale = gameSpeed;
    }

    public void AddToScore() {
        currentLevelScore += pointsPerBlockDestroyed;
        scoreText.text = currentLevelScore.ToString();
    }

    public void SetEndOfLevelScore() {
        currentScore = currentLevelScore;
    }

    public void ResetGameStatus() {
        gameObject.SetActive(false);
        Destroy(gameObject);
    }

    public bool IsAutoPlayEnabled() {
        return isAutoPlayEnabled;
    }

    public void ReloadLevel() {
        currentLevelScore = currentScore;
        scoreText.text = currentScore.ToString();
        loader.ReloadScene();
    }

}
