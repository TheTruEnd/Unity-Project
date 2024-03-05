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
    public float damage;

    private void OnEnable()
    {
        rb.velocity = new Vector2(speed, 0);

        int score = GameData.Instance.score;
        int index = score / 10;
        
        if (index >= GameData.Instance.bulletData.bulletInfos.Count)
        {
            index = GameData.Instance.bulletData.bulletInfos.Count - 1;
        }

        sr.sprite = GameData.Instance.bulletData.bulletInfos[index].sprite;
        damage = GameData.Instance.bulletData.bulletInfos[index].damage;
    }

    public void CheckIfChangeBulletSprite()
    {
        
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Block"))
        {
            var block = other.gameObject.GetComponent<Block>();
            block.TakeDamage(damage);
            gameObject.SetActive(false);
        }
    }
}
