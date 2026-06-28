using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(menuName = "Dialogue/DialogueData")]
public class Dialogue_Data : ScriptableObject
{
    public Dialogue_group Dialogue_Group;
}



//最小単位　1つのセリフのプロパティを持つ
[System.Serializable]
public class Dialogue_line
{
    [SerializeField, Header("発言者")]
    public charctor speaker;
    [SerializeField, Header("表情")]
    public Expression expression;
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

