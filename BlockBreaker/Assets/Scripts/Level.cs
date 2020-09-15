using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour {

    [SerializeField] private int numberOfBlocks;

    private SceneLoader loader;
    // Start is called before the first frame update
    void Start() {
        loader = GetComponent<SceneLoader>();
    }

    public void CountBlocks() {
        numberOfBlocks++;
    }

    private void LoadNextLevel() {
        loader.LoadNextScene();
    }

    public void ReduceBlockCount() {
        numberOfBlocks--;
        if (numberOfBlocks <= 0)
            LoadNextLevel();
    }
}

