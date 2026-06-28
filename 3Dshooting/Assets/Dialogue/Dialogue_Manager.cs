using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Dialogue_Manager : MonoBehaviour
{
    public Dialogue_Data Dialogue_test;
    public Sprite_Data Sprite_Data;
    private Dictionary<charctor, sprite_charctor_expression> sprite;
    // Start is called before the first frame update
    void Start()
    {
        sprite = GetSpriteDictionary(Sprite_Data);
        StartCoroutine(DialogueForward(0));
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator DialogueForward(int SeqenceNumber)//会話を進める関数 　引数同じ場面(チュートリアルやボス戦)などのphaseナンバー
    {
        for (int i = 0; i < Dialogue_test.Dialogue_Group.DialogueSequence[SeqenceNumber].lines.Count; i++)
        {
            charctor speakertype = Dialogue_test.Dialogue_Group.DialogueSequence[SeqenceNumber].lines[i].speaker;
            string speakerName = (speakertype == charctor.Player) ? PL_Data.PL_name : speakertype.ToString();
            string line = Dialogue_test.Dialogue_Group.DialogueSequence[SeqenceNumber].lines[i].text;
            Expression expression = Dialogue_test.Dialogue_Group.DialogueSequence[SeqenceNumber].lines[i].expression;
            Debug.Log(speakerName + ":" + line);
            Debug.Log(sprite[speakertype].charctor[expression]);
            //左クリックをして、話すと次に進む
            yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
            yield return new WaitUntil(() => Input.GetMouseButtonUp(0));
        }
    }

    private class sprite_charctor_expression
    {
        public Dictionary<Expression, Sprite> charctor = new Dictionary<Expression, Sprite>();
    }


    //リストから表情とスプライトの関係を取り出し、dictionaryに変換する関数
    Dictionary<charctor, sprite_charctor_expression>
        GetSpriteDictionary(Sprite_Data data)
    {
        var result = new Dictionary<charctor, sprite_charctor_expression>();//返す値

        // Player
        var player = new sprite_charctor_expression();//プレイヤーのdictionaryを持ったクラス

        foreach (var item in data.Player.sprite_Data_Charctors)//
        {
            player.charctor.Add(item.expression, item.sprite_charctor);
        }

        result[charctor.Player] = player;

        var boss = new sprite_charctor_expression();

        foreach (var item in data.Boss.sprite_Data_Charctors)
        {
            boss.charctor[item.expression] = item.sprite_charctor;
        }

        result[charctor.Boss] = boss;

        // Pet
        var pet = new sprite_charctor_expression();

        foreach (var item in data.pet.sprite_Data_Charctors)
        {
            pet.charctor[item.expression] = item.sprite_charctor;
        }

        result[charctor.pet] = pet;

        return result;
    }
}

