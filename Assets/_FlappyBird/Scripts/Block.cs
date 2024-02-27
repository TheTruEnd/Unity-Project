using System.Runtime.Serialization;
using GameTool;
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
            Debug.Log("Hit Block");
            other.gameObject.SetActive(false);
        }
    }
}
