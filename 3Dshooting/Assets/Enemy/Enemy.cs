using System;
using System.Collections;
using System.Collections.Generic;
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
}


public class EN_Event//敵の行動の実行時間と
{
    public float time;
    public Action action;
}
