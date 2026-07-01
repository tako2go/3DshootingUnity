using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public enum GamePhase
    {
        Battle,//戦闘
        talk,//会話
        Tutorial,//チュートリアルの操作受付
        CLEAR,
    }
    public enum BattlePhase
    {
        Tutorial_battle,//チュートリアル
        middle_battle,//雑魚敵がたくさん出る中盤
        Boss_battle,//ボス戦
    }

    public BattlePhase nowBattlePhase;
    public GamePhase nowGamePhase;
    [SerializeField] private EN_Manager EN_Manager;
    [SerializeField] private Dialogue_Manager dialogue_Manager;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        nowBattlePhase = BattlePhase.Boss_battle;
        nowGamePhase = GamePhase.talk;
        EN_Manager.SpawnEnemy(EN_Manager.EN_Boss);
        dialogue_Manager.DialogueFinished += () =>//会話終了時に戦闘に戻す
        {
            nowGamePhase = GamePhase.Battle;
        };
    }

}
