using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Dialogue/SpriteData_All")]
public class Sprite_Data : ScriptableObject
{
    public Sprite_Data_charctor Player;
    public Sprite_Data_charctor Boss;
    public Sprite_Data_charctor pet;
}

public enum charctor
{
    Player,
    pet,
    Boss,
    none,//キャラクター以外
}


public enum Expression
{
    Normal,
    fine,
    Smile,
    Angry,
    frightened,
}