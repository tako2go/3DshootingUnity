using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Dialogue/SpriteData_charctor")]
public class Sprite_Data_charctor : ScriptableObject
{
    public List<Sprite_Data_expression> sprite_Data_Charctors;
}

[Serializable]
public class Sprite_Data_expression
{
    [SerializeField, Header("表情")]
    public Charactor_Data.Expression expression;
    [SerializeField, Header("立ち絵")]
    public Sprite sprite_charctor;
}