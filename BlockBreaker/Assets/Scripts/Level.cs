using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour {

    private Block[] blocks;
    [SerializeField] private int numberOfBlocks;

    private SceneLoader loader;
    // Start is called before the first frame update
    void Start() {
        blocks = FindObjectsOfType<Block>();
        loader = GetComponent<SceneLoader>();
        numberOfBlocks = blocks.Length;
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

