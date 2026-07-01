using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(menuName = "Dialogue/DialogueData")]
public class Dialogue_Data : ScriptableObject//最大の単位
{
    [SerializeField] public Dialogue_group Dialogue_Group;
    //-------------------------会話中に誰がどこにいるか-------------------------
    [SerializeField] public Charactor_Data.charctor sprite_right;
    [SerializeField] public Charactor_Data.charctor sprite_left;
    [SerializeField] public Charactor_Data.charctor sprite_dalia;
}



//最小単位　1つのセリフのプロパティを持つ
[System.Serializable]
public class Dialogue_line
{
    [SerializeField, Header("発言者")]
    public Charactor_Data.charctor speaker;
    [SerializeField, Header("表情")]
    public Charactor_Data.Expression expression;
    [SerializeField, Header("発言内容")]
    [TextArea]
    public string text;
}


[System.Serializable]//一つのセリフを集めた、一つの会話
public class DialogueSequence
{
    public List<Dialogue_line> lines;//セリフのまとまり
}

[System.Serializable]//一つの会話(フェーズ0での会話、フェーズ1での会話など)を集めた、一つのシーン
public class Dialogue_group
{
    public List<DialogueSequence> DialogueSequence;
}
