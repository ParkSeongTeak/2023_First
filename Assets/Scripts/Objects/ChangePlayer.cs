using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePlayer: MonoBehaviour
{

    public float thresholdHeight = -6f;
    public Sprite imageUnderThreshold;
    public Sprite defaultImage;

    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (transform.position.y < thresholdHeight)
        {
            spriteRenderer.sprite = imageUnderThreshold;
        }
        else
        {
            spriteRenderer.sprite = defaultImage;
        }
    }
}

