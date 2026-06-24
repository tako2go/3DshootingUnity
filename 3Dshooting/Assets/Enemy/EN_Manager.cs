using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EN_Manager : MonoBehaviour
{
    GameManager GameManager;

    //----------敵オブジェクト----------
    [SerializeField] GameObject EN_Tutorial;
    [SerializeField] GameObject EN_Mob;
    [SerializeField] GameObject EN_Boss;


    //------------中盤---------------
    public int MobNum = 0;//現在の雑魚敵の数
    public float MobTimer = EN_Data.MobApperTime;//雑魚敵が死んでから経った時間
    void Start()
    {
        GameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (GameManager.NowBattlePhase)
        {
            case GameManager.BattlePhase.middle_battle://中盤
                MobTimer += Time.deltaTime;
                if (MobNum < EN_Data.MobMaxNum & MobTimer >= EN_Data.MobApperTime)//雑魚敵の数が最大値より少なかったら
                {
                    SpawnEnemy(EN_Mob,
                    new Vector3(UnityEngine.Random.Range(-NumericalData.MoveBoxX / 2, NumericalData.MoveBoxX / 2), UnityEngine.Random.Range(-NumericalData.MoveBoxY / 2, NumericalData.MoveBoxY / 2), EN_Data.BasePos.z));
                    MobNum++;
                }
                break;
        }
    }


    public void SpawnEnemy(GameObject Enemy, Vector3 Pos)
    {
        Instantiate(Enemy, Pos, EN_Data.BaseRot);
    }

    public enum EN_Name
    {
        EN_Tutorial,
        EN_Mob,
        EN_Boss,
    }
}
