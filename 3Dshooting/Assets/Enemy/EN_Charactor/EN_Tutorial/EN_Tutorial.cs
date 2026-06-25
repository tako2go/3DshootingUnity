using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class EN_Tutorial : Enemy

{    //-----------生成するオブジェクト-----------
    [SerializeField] GameObject Red;
    [SerializeField] GameObject Blue;
    protected override void Start()
    {
        base.Start();
        this.transform.position = EN_Data.BasePos;
        this.transform.rotation = EN_Data.BaseRot;
        //----------------------敵行動----------------------
        //書き方:new EN_Event{ time = 前回の行動からの時間,action = () = >{実行する関数};}}
        events = new List<EN_Event>{
        new EN_Event{ time = 0.5f,action = ()=>{Action.Move_Shot(new Vector3(10, 10, EN_Data.BasePos.z), eventTime = 5, () => { Action.CreateNomal(Blue, DirToTarget(Player.transform.position), EN_Data.EN_BulletSpeed_High, 1f); }, 10);}},
        new EN_Event{ time = 0.5f,action = ()=>{Action.Move_Shot(new Vector3(-10, 10, EN_Data.BasePos.z), eventTime = 1.5f, () => { Action.CreateNomalHoming(Red, this.transform.forward, EN_Data.EN_BulletSpeed_Nomal, 0.8f); }, 10);}},
        new EN_Event{ time = 0.5f,action = ()=>{Action.Move_Shot(EN_Data.BasePos, eventTime = 3, () => { Action.CreateCircleSimultaneous(Blue, DirToTarget(Player.transform.position), EN_Data.EN_BulletSpeed_Nomal, 1f, 5f, 12);
                                                                                                         Action.CreateNomal(Blue, DirToTarget(Player.transform.position), EN_Data.EN_BulletSpeed_High, 1f);}, 5);}},
        new EN_Event{ time = 1f,action = ()=>{StartCoroutine(Action.Straight_Move(new Vector3(0,-10,EN_Data.BasePos.z), eventTime = 0.5f));}},
        new EN_Event{ time = 0.5f,action = ()=>{Action.Move_Shot(new Vector3(-10, 10, EN_Data.BasePos.z), eventTime = 1.5f, () => { Action.CreateFan(Blue, this.transform.forward, EN_Data.EN_BulletSpeed_Low, 0.8f, 10, 100f);}, 15);}},
         };
    }


    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }
}
