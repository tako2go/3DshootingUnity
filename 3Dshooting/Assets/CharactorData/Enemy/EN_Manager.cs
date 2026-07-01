using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EN_Manager : MonoBehaviour
{
    GameManager GameManager;

    //----------敵オブジェクト----------
    public GameObject EN_Tutorial;
    public GameObject EN_Mob;
    public GameObject EN_Boss;


    //------------中盤---------------
    public int MobNum = 0;//現在の雑魚敵の数
    public float MobTimer = EN_Data.MobApperTime;//雑魚敵が死んでから経った時間

    //------------ボス戦---------------

    void Start()
    {
        GameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (GameManager.nowBattlePhase)
        {
            case GameManager.BattlePhase.middle_battle://中盤
                MobTimer += Time.deltaTime;
                if (MobNum < EN_Data.MobMaxNum & MobTimer >= EN_Data.MobApperTime)//雑魚敵の数が最大値より少なかったら
                {
                    SpawnEnemy(EN_Mob);
                    MobNum++;
                }
                break;

            case GameManager.BattlePhase.Boss_battle:

                break;
        }
    }


    public void SpawnEnemy(GameObject Enemy)
    {
        Instantiate(Enemy, EN_Data.BasePos, EN_Data.BaseRot);
    }

    public enum EN_Name
    {
        EN_Tutorial,
        EN_Mob,
        EN_Boss,
    }
}
