using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public enum GamePhase
    {
        Battle,//戦闘
        talk,//会話
        Tutorial,//チュートリアルの操作受付
    }
    public enum BattlePhase
    {
        Tutorial_battle,//チュートリアル
        middle_battle,//雑魚敵がたくさん出る中盤
        Boss_battle,//ボス戦
    }

    public BattlePhase nowBattlePhase;
    public GamePhase nowGamePhase;
    private EN_Manager EN_Manager;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        EN_Manager = GameObject.FindWithTag("EN_Manager").GetComponent<EN_Manager>();

        nowBattlePhase = BattlePhase.Boss_battle;
        nowGamePhase = GamePhase.talk;
        EN_Manager.SpawnEnemy(EN_Manager.EN_Boss);
    }

}
