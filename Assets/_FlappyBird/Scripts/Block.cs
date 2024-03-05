using System.Runtime.Serialization;
using GameTool;
using UnityEditor.Build.Content;
using UnityEngine;


public class Block : BasePooling
{
    public BlockType blockType;
    private float curHP;
    [SerializeField]private float MaxHP;
    private SpriteRenderer sr;
    
    public eSoundName sound;

    private void OnEnable()
    {
        sr = GetComponent<SpriteRenderer>();
        Disable(10f);
    }

    public void SetData()
    {
        SetShotSFX();
        MaxHP = GameData.Instance.blockData.listBlockSprites[(int)blockType].spriteInfos.maxHP;
        curHP = MaxHP;
        sr.sprite = GameData.Instance.blockData.listBlockSprites[(int)blockType].spriteInfos.listSprite[2];
    }

    public void TakeDamage(float amount)
    {
        curHP -= amount;
        SetSprite();
        AudioManager.Instance.Shot(sound);
    }


    public void SetSprite()
    {
        if (curHP / MaxHP <= 1f / 3)
        {
            sr.sprite = GameData.Instance.blockData.listBlockSprites[(int)blockType].spriteInfos.listSprite[0];
        }
        else if (curHP / MaxHP <= 2f / 3)
        {
            sr.sprite = GameData.Instance.blockData.listBlockSprites[(int)blockType].spriteInfos.listSprite[1];
        }

        if (curHP <= 0)
        {
            GameMenu.Instance.UpdateScore((int)blockType + 1);
            Disable();
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        // if (other.gameObject.CompareTag("Bullet"))
        // {
        //     curHP -= 3;
        //     Debug.Log(curHP);
        // }
        //
        // float curHP_percent = (float)curHP/GameData.Instance.blockData.listBlockSprites[(int)blockType].spriteInfos.maxHP;
        // if (curHP_percent <= 2.0 / 3 && curHP_percent > 1.0 / 3)
        // {
        //     sr.sprite = GameData.Instance.blockData.listBlockSprites[(int)blockType].spriteInfos.listSprite[1];
        // }
        // if (curHP_percent <= 1.0 / 3)
        // {
        //     sr.sprite = GameData.Instance.blockData.listBlockSprites[(int)blockType].spriteInfos.listSprite[0];
        // }
        //
        // if (curHP <= 0)
        // {
        //     gameObject.SetActive(false);
        // }
    }
    
    public void SetShotSFX()
    {
        if (blockType == BlockType.Wood)
        {
            sound = eSoundName.Wood_Sound;
        }
        if (blockType == BlockType.Stone)
        {
            sound = eSoundName.Stone_Sound;
        }
        if (blockType == BlockType.Metal)
        {
            sound = eSoundName.Metal_Sound;
        }
    }
}