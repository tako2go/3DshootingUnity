using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Security;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    protected Transform Player;

    //-----------Enemyの行動関係-----------
    [HideInInspector] public int EN_HP;

    //-----------Enemyの行動関係-----------
    protected bool MoveFlag = false;
    protected EN_Action Action;
    protected List<EN_Event> events;


    //-----------関数の実行回数や時間-----------
    protected int count = 0;
    protected float timer = 0;
    protected float eventTime = 0;


    protected virtual void Start()
    {
        Player = GameObject.FindWithTag("Player").GetComponent<Transform>();
        Action = this.GetComponent<EN_Action>();
    }

    protected virtual void Update()
    {
        timer += Time.deltaTime;
        if (count < events.Count - 1)
        {
            if (timer >= events[count].time)
            {
                events[count].action?.Invoke();
                count++;
            }
        }
        else
        {
            count = 0;
            timer = 0;
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

    protected float ConvertTime(float IntervalTime)//前回の行動からの時間をいれると、その行動の時間にしてくれる
    {
        return timer + eventTime + IntervalTime;
    }
}



public class EN_Event//敵の行動の実行時間と
{
    public float time;
    public Action action;
}
