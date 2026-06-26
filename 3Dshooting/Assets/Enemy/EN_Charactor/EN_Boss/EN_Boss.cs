using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EN_Boss : Enemy
{
    [SerializeField] GameObject Red;
    [SerializeField] GameObject Blue;
    [SerializeField] GameObject Circle_Parent;
    [SerializeField] GameObject RotateNomal_Parent;

    EN_Manager EN_Manager;
    protected override void Start()
    {
        base.Start();
        new Vector3(UnityEngine.Random.Range(-NumericalData.MoveBoxX / 2, NumericalData.MoveBoxX / 2), UnityEngine.Random.Range(-NumericalData.MoveBoxY / 2, NumericalData.MoveBoxY / 2), EN_Data.BasePos.z);
        EN_MaxHP = 150;
        EN_HP = EN_MaxHP;
        EN_Manager = GameObject.FindWithTag("EN_Manager").GetComponent<EN_Manager>();
        //----------------------敵行動----------------------
        //書き方:new EN_Event{ time = 前回の行動からの時間,action = () = >{実行する関数};}}
        base.Start();
        new Vector3(UnityEngine.Random.Range(-NumericalData.MoveBoxX / 2, NumericalData.MoveBoxX / 2), UnityEngine.Random.Range(-NumericalData.MoveBoxY / 2, NumericalData.MoveBoxY / 2), EN_Data.BasePos.z);
        EN_Manager = GameObject.FindWithTag("EN_Manager").GetComponent<EN_Manager>();
        //----------------------敵行動----------------------
        //書き方:new EN_Event{ time = 実行する時間,action = () = >{実行する関数};}}
        phase = new List<EN_Phase>();
        // {
        //     new EN_Phase
        //     {
        //          events = new List<EN_Event>{
        // new EN_Event{ time = 1.0f,action = ()=>{Action.Move_Shot(EN_Data.BasePos, eventTime = 0, () => { Action.CreateCircleSimultaneous(Blue, DirToTarget(Player.transform.position), EN_Data.EN_BulletSpeed_Nomal, 1f, 5f, 12);}, 1);}},
        // new EN_Event{ time = 0.5f,action = ()=>{Action.Move_Shot(EN_Data.BasePos, eventTime = 0, () => { Action.CreateCircleSimultaneous(Blue, DirToTarget(Player.transform.position), EN_Data.EN_BulletSpeed_Nomal, 1f, 5f, 12);}, 1);}},
        // new EN_Event{ time = 1.0f,action = ()=>{StartCoroutine(Action.Straight_Move(new Vector3(EnableMoveX,Player.transform.position.y,EN_Data.BasePos.z), eventTime = 0.5f));}},
        // new EN_Event{ time = 0f,action = ()=>{Action.Move_Shot(new Vector3(-EnableMoveX,this.transform.position.y,EN_Data.BasePos.z), eventTime = 10, () => { Action.CreateNomal(Blue, this.transform.forward, EN_Data.EN_BulletSpeed_Low, 1f); }, 10);}},
        // new EN_Event{ time = 1.0f,action = ()=>{Action.Move_Shot(RandomVecto3(), eventTime = 1.5f, () => { Action.CreateFan(Blue, DirToTarget(Player.transform.position) , EN_Data.EN_BulletSpeed_Low, 0.7f, 5, 60);}, 2);}},
        // new EN_Event{ time = 1.0f,action = ()=>{StartCoroutine(Action.Straight_Move(new Vector3(-EnableMoveX,Player.transform.position.y,EN_Data.BasePos.z), eventTime = 0.5f));}},
        // new EN_Event{ time = 0f,action = ()=>{Action.Move_Shot(new Vector3(EnableMoveX,this.transform.position.y,EN_Data.BasePos.z), eventTime = 10, () => { Action.CreateNomal(Blue, this.transform.forward, EN_Data.EN_BulletSpeed_Low, 1f); }, 10);}},
        // new EN_Event{ time = 1.0f,action = ()=>{Action.Move_Shot(RandomVecto3(), eventTime = 1.5f, () => { Action.CreateFan(Blue, DirToTarget(Player.transform.position) , EN_Data.EN_BulletSpeed_Low, 0.7f, 5, 60);}, 2);}},
        // new EN_Event{ time = 1.0f,action = ()=>{StartCoroutine(Action.Straight_Move(EN_Data.BasePos, eventTime = 0.5f));}},
        // new EN_Event{ time = 1.0f,action = ()=>{Action.Move_Shot(EN_Data.BasePos, eventTime = 3, () => { Action.CreateRotateNomal(Red,Blue, new Vector3(1,-1,-1),new Vector3(-1,1,-1), 5f,10,EN_Data.EN_BulletSpeed_Nomal, 0.8f); }, 1);}},
        //  }
        //     },
        // new EN_Phase
        // {

        // }
        // };

        for (int i = 0; i < 3; i++)
        {
            phase.Add(new EN_Phase());
        }

        //--------------フェーズ0--------------
        AddEvent(0, new EN_Event { time = 1.0f, action = () => { Action.Move_Shot(RandomVecto3(), eventTime = 6, () => { Action.CreateNomal(Blue, DirToTarget(Player.transform.position), EN_Data.EN_BulletSpeed_Nomal, EN_Data.EN_BulletSize_Nomal); }, 20); } });
        AddEvent(0, new EN_Event
        {
            time = 1.0f,
            action = () =>
            {
                Action.Move_Shot(RandomVecto3(), eventTime = 3, () =>
                {
                    Action.CreateNomalHoming(Red, this.transform.forward, EN_Data.EN_BulletSpeed_Low, EN_Data.EN_BulletSize_Nomal * 0.8f);
                    Action.CreateFan(Blue, DirToTarget(Player.transform.position), EN_Data.EN_BulletSpeed_Low, EN_Data.EN_BulletSize_Nomal * 0.7f, 12, 60);
                }, 3);
            }
        });
        AddEvent(0, new EN_Event { time = 0.5f, action = () => { StartCoroutine(Action.Straight_Move(new Vector3(EnableMoveX, Player.transform.position.y, EN_Data.BasePos.z), eventTime = 0.5f)); } });
        for (int i = 20; i > 0; i--) { int copy = i; AddEvent(0, new EN_Event { time = 0.15f, action = () => { Action.Move_Shot(EN_Data.BasePos, eventTime = 0f, () => { Action.CreateCircleSimultaneous(Blue, DirToTarget(Player.transform.position), EN_Data.EN_BulletSpeed_Nomal, EN_Data.EN_BulletSize_Nomal, copy / 3, 12); }, 1); } }); }//キャプチャ問題対策でcopy変数を作成 iをつかうと同じ変数であるため、最終的にi = 21となったiしか参照しない
        for (int i = 1; i <= 20; i++) { int copy = i; AddEvent(0, new EN_Event { time = 0.15f, action = () => { Action.Move_Shot(EN_Data.BasePos, eventTime = 0f, () => { Action.CreateCircleSimultaneous(Blue, DirToTarget(Player.transform.position), EN_Data.EN_BulletSpeed_Nomal, EN_Data.EN_BulletSize_Nomal, copy / 3, 12); }, 1); } }); }
        // for (int i = 11; i > 0; i -= 2) { int copy = i; }

        //--------------フェーズ1--------------


        //--------------フェーズ2--------------
        AddEvent(2, new EN_Event { time = 1.0f, action = () => { StartCoroutine(Action.Straight_Move(EN_Data.BasePos, eventTime = 1.0f)); ; } });
        AddEvent(2, new EN_Event { time = 1.0f, action = () => { Action.Move_Shot(EN_Data.BasePos, eventTime = 0, () => { Action.CreateRotateNomal(RotateNomal_Parent, Blue, new Vector3(1, -1, -1), new Vector3(-1, 1, -1), 5f, 30, EN_Data.EN_BulletSpeed_Nomal, EN_Data.EN_BulletSize_Nomal * 0.8f); }, 1); } });
        AddEvent(2, new EN_Event { time = 0.0f, action = () => { Action.Move_Shot(EN_Data.BasePos, eventTime = 0, () => { Action.CreateRotateNomal(RotateNomal_Parent, Blue, new Vector3(-1, -1, -1), new Vector3(1, 1, -1), 5f, 30, EN_Data.EN_BulletSpeed_Nomal, EN_Data.EN_BulletSize_Nomal * 0.8f); }, 1); } });
        AddEvent(2, new EN_Event { time = 1.0f, action = () => { Action.Move_Shot(EN_Data.BasePos, eventTime = 0, () => { StartCoroutine(Action.Straight_Move(EN_Data.BasePos, eventTime = 3f)); }, 1); } });
        AddEvent(2, new EN_Event { time = 1.0f, action = () => { StartCoroutine(Action.Straight_Move(new Vector3(-10f, EN_Data.BasePos.y, EN_Data.BasePos.z), eventTime = 0.5f)); } });
        AddEvent(2, new EN_Event { time = 0.0f, action = () => { Action.Move_Shot(new Vector3(10f, EN_Data.BasePos.y, EN_Data.BasePos.z), eventTime = 1.0f, () => { Action.CreateCircle(Circle_Parent, Blue, EN_Data.EN_BulletSpeed_Nomal, EN_Data.EN_BulletSize_Nomal * 0.8f, 5f, 8, 1.0f, 0.3f); }, 2); } });
        AddEvent(2, new EN_Event { time = 1.0f, action = () => { StartCoroutine(Action.Straight_Move(new Vector3(0f, -10f, EN_Data.BasePos.z), eventTime = 0.5f)); } });
        AddEvent(2, new EN_Event { time = 1.0f, action = () => { Action.Move_Shot(new Vector3(0, 10, EN_Data.BasePos.z), eventTime = 8, () => { Action.CreateFan(Blue, this.transform.forward, EN_Data.EN_BulletSpeed_Low, EN_Data.EN_BulletSize_Nomal * 0.7f, 12, 60); }, 16); } });
    }

    protected override void Update()
    {
        base.Update();
        if ((float)EN_HP / EN_MaxHP <= (1.0f / 3))
        {
            if (now_phase != 2)
            {
                now_phase = 2;
                eventCount = 0;
            }

        }
        else if ((float)EN_HP / EN_MaxHP <= (2.0f / 3))
        {
            if (now_phase != 1)
            {
                now_phase = 1;
                eventCount = 0;
            }
        }
        else if ((float)EN_HP / EN_MaxHP <= (3f / 3))
        {
            if (now_phase != 0)
            {
                now_phase = 0;
                eventCount = 0;
            }
        }

        if (EN_HP <= 0)
        {
            Destroy(this.gameObject);
        }
    }




}
