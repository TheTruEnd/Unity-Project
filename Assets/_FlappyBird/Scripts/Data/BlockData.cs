using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Block Data", menuName = "Data/Block Data")]
public class BlockData : ScriptableObject
{
    public List<BlockSprite> listBlockSprites;
}

[Serializable]
public class BlockSprite
{
    public BlockType blockType;
    public SpriteInfos spriteInfos;
}

[Serializable]
public class SpriteInfos
{
    public List<Sprite> listSprite;
    public float maxHP;
}

public enum BlockType
{
    Wood = 0,
    Stone = 1,
    Metal = 2,
}