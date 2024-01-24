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
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Block"))
        {
            Debug.Log("Hit Bullet");
            other.gameObject.SetActive(false);
        }
    }
}
