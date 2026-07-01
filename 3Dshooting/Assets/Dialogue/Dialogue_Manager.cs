using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class Dialogue_Manager : MonoBehaviour
{
    //------------------取り込むアセット------------------
    [SerializeField] private Dialogue_Data Dialogue_Boss;
    [SerializeField] private Sprite_Data Sprite_Data;

    private Dictionary<Charactor_Data.charctor, sprite_charctor_expression> sprite;//スプライトと名前、表情を対応させたdictionary
    [SerializeField] private TextMeshProUGUI Text_Name;//話し手の名前
    [SerializeField] private TextMeshProUGUI Text_line;//セリフ内容;

    //------------------キャラクター表示------------------
    [SerializeField] private Image Right_img;
    [SerializeField] private Image left_img;
    [SerializeField] private Image dalia_img;//ダリア専用のプレイヤーの隣の画像

    void Start()
    {
        sprite = GetSpriteDictionary(Sprite_Data);
        StartCoroutine(DialogueForward(0));
    }

    // Update is called once per frame
    void Update()
    {

    }

    public IEnumerator DialogueForward(int SeqenceNumber)//会話を進める関数 　引数同じ場面(チュートリアルやボス戦)などのphaseナンバー
    {
        DialogueSequence dialogueSequence = Dialogue_Boss.Dialogue_Group.DialogueSequence[SeqenceNumber];//今回の実行で行う会話の内容
        //-----------------------登場キャラのノーマル画像を入れる-----------------------
        if (Dialogue_Boss.sprite_right != Charactor_Data.charctor.none) Right_img.sprite = sprite[Dialogue_Boss.sprite_right].expression[Charactor_Data.Expression.Angry];
        if (Dialogue_Boss.sprite_left != Charactor_Data.charctor.none) left_img.sprite = sprite[Dialogue_Boss.sprite_left].expression[Charactor_Data.Expression.Normal];
        if (Dialogue_Boss.sprite_dalia != Charactor_Data.charctor.none) dalia_img.sprite = sprite[Dialogue_Boss.sprite_dalia].expression[Charactor_Data.Expression.Normal];
        for (int talkCount = 0; talkCount < dialogueSequence.lines.Count; talkCount++)
        {
            Charactor_Data.charctor speakertype = dialogueSequence.lines[talkCount].speaker;//話し手の種類を取得
            string speakerName = (speakertype == Charactor_Data.charctor.Player) ? PL_Data.PL_name : speakertype.ToString();//もしプレイヤーだったらプレイヤー名、それ以外だったらそのまま代入
            string line = dialogueSequence.lines[talkCount].text;//セリフを取得
            Charactor_Data.Expression expression = dialogueSequence.lines[talkCount].expression;//表情を取得

            //-----------------------表示テキスト変更-----------------------
            Text_Name.text = speakerName;
            Text_line.text = line;

            ////-----------------------表示スプライト変更-----------------------
            Right_img.color = new Color32(175, 175, 175, 255);//すべて色を暗くする
            left_img.color = new Color32(175, 175, 175, 255);
            dalia_img.color = new Color32(175, 175, 175, 255);
            if (speakertype == Dialogue_Boss.sprite_right)
            {
                Right_img.sprite = sprite[Dialogue_Boss.sprite_right].expression[expression];
                Right_img.color = new Color32(255, 255, 255, 255);//しゃべっているキャラのみ色を明るく
            }
            else if (speakertype == Dialogue_Boss.sprite_left)
            {
                left_img.sprite = sprite[Dialogue_Boss.sprite_left].expression[expression];
                left_img.color = new Color32(255, 255, 255, 255);
            }
            else if (speakertype == Dialogue_Boss.sprite_dalia)
            {
                dalia_img.sprite = sprite[Dialogue_Boss.sprite_dalia].expression[expression];
                dalia_img.color = new Color32(255, 255, 255, 255);
            }

            //左クリックをして、話すと次に進む
            yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
            yield return new WaitUntil(() => Input.GetMouseButtonUp(0));
        }
        DialogueFinished?.Invoke();
    }


    public event Action DialogueFinished;//会話終了時に実行する関数 phaseのインクリメントを敵側から実行


    private class sprite_charctor_expression
    {
        public Dictionary<Charactor_Data.Expression, Sprite> expression = new Dictionary<Charactor_Data.Expression, Sprite>();
    }


    string NameConvert(Charactor_Data.charctor speaker)//enum型のcharactorからストリング型の名前に変更する。
    {
        string speakerName;
        if (speaker == Charactor_Data.charctor.Player)//speakerがプレイヤーだったらプレイヤーが最初に決めた名前に変更
        {
            speakerName = PL_Data.PL_name;
        }
        else if (speaker == Charactor_Data.charctor.none)//speakerがnoneだったら空白
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
    Dictionary<Charactor_Data.charctor, sprite_charctor_expression>
        GetSpriteDictionary(Sprite_Data data)
    {
        var result = new Dictionary<Charactor_Data.charctor, sprite_charctor_expression>();//返す値

        // Player
        var player = new sprite_charctor_expression();//プレイヤーのdictionaryを持ったクラス

        foreach (var item in data.Player.sprite_Data_Charctors)//
        {
            player.expression.Add(item.expression, item.sprite_charctor);
        }

        result[Charactor_Data.charctor.Player] = player;

        var boss = new sprite_charctor_expression();

        foreach (var item in data.Boss.sprite_Data_Charctors)
        {
            boss.expression[item.expression] = item.sprite_charctor;
        }

        result[Charactor_Data.charctor.フィラーネ] = boss;

        // Pet
        var pet = new sprite_charctor_expression();

        foreach (var item in data.pet.sprite_Data_Charctors)
        {
            pet.expression[item.expression] = item.sprite_charctor;
        }

        result[Charactor_Data.charctor.ダリア] = pet;

        return result;
    }
}

