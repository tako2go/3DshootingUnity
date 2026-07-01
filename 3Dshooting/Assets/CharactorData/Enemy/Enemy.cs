using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Security;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    protected Transform Player;

    //-----------Enemyの行動関係-----------
    public int EN_HP;
    protected int EN_MaxHP;

    //-----------Enemyの行動関係-----------
    protected int now_phase = 0;
    protected bool MoveFlag = false;
    protected EN_Action Action;
    protected List<EN_Event> events;
    protected List<EN_Phase> phase;

    protected float EnableMoveX = NumericalData.MoveBoxX / 2;//移動範囲
    protected float EnableMoveY = NumericalData.MoveBoxY / 2;

    //-----------関数の実行回数や時間-----------
    protected int eventCount = 0;
    protected float timer = 0;
    protected float eventTime = 0;

    protected GameManager gameManager;
    protected Dialogue_Manager dialogue_Manager;
    protected virtual void Start()
    {
        Player = GameObject.FindWithTag("Player").GetComponent<Transform>();
        Action = this.GetComponent<EN_Action>();
        gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        dialogue_Manager = GameObject.FindWithTag("Dialogue_Manager").GetComponent<Dialogue_Manager>();
    }

    protected virtual void Update()
    {
        if (gameManager.nowGamePhase == GameManager.GamePhase.talk) return;//会話シーン中はストップ

        timer += Time.deltaTime;
        if (phase[now_phase].events.Count <= eventCount) return;
        if (timer >= phase[now_phase].events[eventCount].time + eventTime)
        {
            phase[now_phase].events[eventCount].action?.Invoke();
            eventCount++;
            timer = 0;
            if (eventCount >= phase[now_phase].events.Count)
            {
                eventCount = 0;
            }
        }
    }

    void OnCollisionEnter(Collision collision)//当たり判定
    {
        if (collision.gameObject.CompareTag("PL_Bullet"))
        {
            EN_HP--;
            Destroy(collision.gameObject);
        }
    }

    protected Vector3 DirToTarget(Vector3 Target)
    {
        return Target - this.transform.position;
    }

    // protected float ConvertTime(int index, float IntervalTime)//前回の行動からの時間をいれると、その行動の時間にしてくれる
    // {
    //     return timer + events[index - 1].eventTime;
    // }

    protected Vector3 RandomVecto3()
    {
        return new Vector3(UnityEngine.Random.Range(-EnableMoveX, EnableMoveX), UnityEngine.Random.Range(-EnableMoveY, EnableMoveY), EN_Data.BasePos.z);//移動可能範囲内でランダムな位置を生成
    }

    protected void AddEvent(int index, EN_Event Added_event)//index:phase Added_event:行動
    {
        phase[index].events.Add(Added_event);
    }
}

public class EN_Phase
{
    public List<EN_Event> events = new List<EN_Event>();
}

public class EN_Event//敵の行動の実行時間と
{
    public float time;
    public float eventTime;
    public Action action;
}
