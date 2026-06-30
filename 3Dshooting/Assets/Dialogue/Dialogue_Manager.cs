using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class Dialogue_Manager : MonoBehaviour
{
    public Dialogue_Data Dialogue_test;
    public Sprite_Data Sprite_Data;
    private Dictionary<charctor, sprite_charctor_expression> sprite;
    public TextMeshProUGUI Text_Name;//話し手の名前
    public TextMeshProUGUI Text_line;//セリフ内容;

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
        DialogueSequence dialogueSequence = Dialogue_test.Dialogue_Group.DialogueSequence[SeqenceNumber];//今回の実行で行う会話の内容
        for (int i = 0; i < dialogueSequence.lines.Count; i++)
        {
            charctor speakertype = dialogueSequence.lines[i].speaker;//話し手の種類を取得
            string speakerName = (speakertype == charctor.Player) ? PL_Data.PL_name : speakertype.ToString();//もしプレイヤーだったらプレイヤー名、それ以外だったらそのまま代入
            string line = dialogueSequence.lines[i].text;//セリフを取得
            Expression expression = dialogueSequence.lines[i].expression;//表情を取得

            //表示テキスト変更
            Text_Name.text = speakerName;
            Text_line.text = line;
            //左クリックをして、話すと次に進む
            yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
            yield return new WaitUntil(() => Input.GetMouseButtonUp(0));
        }
        DialogueFinished?.Invoke();
    }

    public event Action DialogueFinished;//会話終了時に実行する関数 phaseのインクリメントを敵側から実行

    private class sprite_charctor_expression
    {
        public Dictionary<Expression, Sprite> charctor = new Dictionary<Expression, Sprite>();
    }


    string NameConvert(charctor speaker)//enum型のcharactorからストリング型の名前に変更する。
    {
        string speakerName;
        if (speaker == charctor.Player)//speakerがプレイヤーだったらプレイヤーが最初に決めた名前に変更
        {
            speakerName = PL_Data.PL_name;
        }
        else if (speaker == charctor.none)//speakerがnoneだったら空白
        {
            speakerName = "";
        }
        else//上記以外だったら、そのままのものをString型にして代入
        {
            speakerName = speaker.ToString();
        }
        return speakerName;
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

