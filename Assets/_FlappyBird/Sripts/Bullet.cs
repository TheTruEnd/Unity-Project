using System;
using System.Collections;
using System.Collections.Generic;
using GameTool;
using UnityEngine;

public class Bullet : BasePooling
{
    public float speed;
    public Rigidbody2D rb;
    public SpriteRenderer sr;

    private void Update()
    {
        rb.velocity = new Vector2(speed, 0);
    }
}
