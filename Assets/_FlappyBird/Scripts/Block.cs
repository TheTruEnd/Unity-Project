using System.Runtime.Serialization;
using GameTool;
using UnityEditor.Build.Content;
using UnityEngine;


public class Block : BasePooling
{
    public BlockType blockType;
    private float curHP;
    private SpriteRenderer sr;
    private void OnEnable()
    {
        sr = GetComponent<SpriteRenderer>();
        Disable(10f);
    }

    public void SetData()
    {
        curHP = GameData.Instance.blockData.listBlockSprites[(int)blockType].spriteInfos.maxHP;
        sr.sprite = GameData.Instance.blockData.listBlockSprites[(int)blockType].spriteInfos.listSprite[2];
    }
    
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            curHP -= 3;
            Debug.Log(curHP);
        }
        
        float curHP_percent = (float)curHP/GameData.Instance.blockData.listBlockSprites[(int)blockType].spriteInfos.maxHP;
        if (curHP_percent <= 2.0 / 3 && curHP_percent > 1.0 / 3)
        {
            sr.sprite = GameData.Instance.blockData.listBlockSprites[(int)blockType].spriteInfos.listSprite[1];
        }
        if (curHP_percent <= 1.0 / 3)
        {
            sr.sprite = GameData.Instance.blockData.listBlockSprites[(int)blockType].spriteInfos.listSprite[0];
        }

        if (curHP <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}