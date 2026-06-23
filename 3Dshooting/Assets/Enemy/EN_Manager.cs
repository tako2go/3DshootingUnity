using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EN_Manager : MonoBehaviour
{
    GameManager GameManager;
    public Dictionary<EN_Name, GameObject> enemies = new Dictionary<EN_Name, GameObject>();
    [SerializeField] GameObject EN_Tutorial;
    [SerializeField] GameObject EN_Mob;
    [SerializeField] GameObject EN_Boss;

    public int MobNum = 0;
    void Start()
    {
        enemies.Add(EN_Name.EN_Tutorial, EN_Tutorial);
        enemies.Add(EN_Name.EN_Mob, EN_Mob);
        enemies.Add(EN_Name.EN_Boss, EN_Boss);
        GameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (GameManager.NowBattlePhase)
        {
            case GameManager.BattlePhase.middle_battle://中盤
                if (MobNum < EN_Data.MobMaxNum)//雑魚敵の数が最大値より少なかったら
                {
                    SpawnEnemy(EN_Name.EN_Mob,
                    new Vector3(UnityEngine.Random.Range(-NumericalData.MoveBoxX / 2, NumericalData.MoveBoxX / 2), UnityEngine.Random.Range(-NumericalData.MoveBoxY / 2, NumericalData.MoveBoxY / 2), EN_Data.BasePos.z));
                    MobNum++;
                }
                break;
        }
    }


    public void SpawnEnemy(EN_Name Enemy, Vector3 Pos)
    {
        Instantiate(enemies[Enemy], Pos, EN_Data.BaseRot);
    }

    public enum EN_Name
    {
        EN_Tutorial,
        EN_Mob,
        EN_Boss,
    }
}
