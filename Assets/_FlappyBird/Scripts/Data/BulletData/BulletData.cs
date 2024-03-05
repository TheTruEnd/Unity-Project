using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Bullet Data", menuName = "Data/Bullet Data")]
public class BulletData : ScriptableObject
{
    public List<BulletInfo> bulletInfos;
}
[Serializable]
public class BulletInfo
{
    public float damage;
    public Sprite sprite;
}
