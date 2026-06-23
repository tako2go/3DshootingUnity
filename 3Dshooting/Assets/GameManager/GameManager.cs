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
    }
    public enum BattlePhase
    {
        Tutorial_battle,//チュートリアル
        middle_battle,//雑魚敵がたくさん出る中盤
        Boss_battle,//ボス戦
    }

    BattlePhase NowBattlePhase;
    EN_Manager EN_Manager;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        EN_Manager = GameObject.FindWithTag("EN_Manager").GetComponent<EN_Manager>();
        NowBattlePhase = BattlePhase.Tutorial_battle;
    }

    void Update()
    {
        NowBattlePhase = BattlePhase.middle_battle;

    }

}
