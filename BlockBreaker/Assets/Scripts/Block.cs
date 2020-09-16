using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {

    // config params
    [SerializeField] AudioClip breakSound;
    int maxHits;
    [SerializeField] Sprite[] hitSprites;

    // cached references
    Level level;
    SpriteRenderer renderer;

    // state variables
    [SerializeField] int timesHit; // TODO only serialized for debug purposes

    private void Start() {
        renderer = GetComponent<SpriteRenderer>();
        CountBreakableBlocks();
    }

    private void CountBreakableBlocks() {
        level = FindObjectOfType<Level>();
        if (tag == "Breakable")
            level.CountBlocks();

    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (tag == "Breakable") {
            timesHit++;
            int maxHits = hitSprites.Length + 1;
            if (timesHit >= maxHits)
                DestroyBlock();
            else
                ShowNextHitSprite();

        }
    }

    private void ShowNextHitSprite() {
        int spriteIndex = timesHit - 1;
        if (hitSprites[spriteIndex] != null)
            renderer.sprite = hitSprites[spriteIndex];
        else
            Debug.LogError("Block sprite is missing from array" + gameObject.name);
    }

    private void DestroyBlock() {
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position, 0.1f);
        FindObjectOfType<GameStatus>().AddToScore();
        level.ReduceBlockCount();
        Destroy(gameObject);
    }
}
