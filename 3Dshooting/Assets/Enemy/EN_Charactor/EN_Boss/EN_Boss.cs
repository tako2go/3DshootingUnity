using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EN_Boss : Enemy
{
    EN_Manager EN_Manager;
    [SerializeField] private Dialogue_Manager dialogue_Manager;

    //------------------ボスが生成するオブジェクト------------------
    [SerializeField] private GameObject Red;
    [SerializeField] private GameObject Blue;
    [SerializeField] private GameObject Circle_Parent;
    [SerializeField] private GameObject RotateNomal_Parent;

    protected override void Start()
    {
        base.Start();
        EN_Manager = GameObject.FindWithTag("EN_Manager").GetComponent<EN_Manager>();
        EN_MaxHP = 300; EN_HP = EN_MaxHP;
        Dialogue_Manager dialogue_Manager = GameObject.FindWithTag("Dialogue_Manager").GetComponent<Dialogue_Manager>();
        dialogue_Manager.DialogueFinished += () => now_phase++;//会話終了時にphaseをインクリメント
        //----------------------敵行動----------------------
        //書き方:new EN_Event{ time = 実行する時間,action = () = >{実行する関数};}}
        phase = new List<EN_Phase>();

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


        //--------------フェーズ1--------------
        AddEvent(1, new EN_Event { time = 1.0f, action = () => { Action.Move_Shot(EN_Data.BasePos, eventTime = 3f, () => { Action.CreateCircleSimultaneous(Blue, DirToTarget(Player.transform.position), EN_Data.EN_BulletSpeed_Nomal, EN_Data.EN_BulletSize_Nomal, 5, 12); }, 5); } });
        AddEvent(1, new EN_Event { time = 1.0f, action = () => { StartCoroutine(Action.Straight_Move(EN_Data.BasePos, eventTime = 0.5f)); } });
        AddEvent(1, new EN_Event
        {
            time = 1.0f,
            action = () =>
            {
                Action.Move_Shot(EN_Data.BasePos, eventTime = 5f, () =>
                {
                    Action.CretateWave(Blue, DirToTarget(Player.transform.position), EN_Data.EN_BulletSpeed_Low, EN_Data.EN_BulletSize_Nomal, 0, 10f, 0.5f);
                    Action.CretateWave(Blue, DirToTarget(Player.transform.position), EN_Data.EN_BulletSpeed_Low, EN_Data.EN_BulletSize_Nomal, 45, 10f, 0.5f);
                    Action.CretateWave(Blue, DirToTarget(Player.transform.position), EN_Data.EN_BulletSpeed_Low, EN_Data.EN_BulletSize_Nomal, -45, 10f, 0.5f);
                }, 20);
            }
        });

        //--------------フェーズ2--------------
        AddEvent(2, new EN_Event { time = 1.0f, action = () => { StartCoroutine(Action.Straight_Move(EN_Data.BasePos, eventTime = 1.0f)); ; } });
        AddEvent(2, new EN_Event { time = 1.0f, action = () => { Action.Move_Shot(EN_Data.BasePos, eventTime = 0, () => { Action.CreateRotateNomal(RotateNomal_Parent, Blue, new Vector3(1, -1, -1), new Vector3(-1, 1, -1), 5f, 30, EN_Data.EN_BulletSpeed_Nomal, EN_Data.EN_BulletSize_Nomal * 0.8f); }, 1); } });
        AddEvent(2, new EN_Event { time = 0.0f, action = () => { Action.Move_Shot(EN_Data.BasePos, eventTime = 0, () => { Action.CreateRotateNomal(RotateNomal_Parent, Blue, new Vector3(-1, -1, -1), new Vector3(1, 1, -1), 5f, 30, EN_Data.EN_BulletSpeed_Nomal, EN_Data.EN_BulletSize_Nomal * 0.8f); }, 1); } });
        AddEvent(2, new EN_Event { time = 0.0f, action = () => { Action.Move_Shot(EN_Data.BasePos, eventTime = 0, () => { Action.CreateRotateNomal(RotateNomal_Parent, Blue, new Vector3(1, 0, -1), new Vector3(-1, 0, -1), 5f, 30, EN_Data.EN_BulletSpeed_Nomal, EN_Data.EN_BulletSize_Nomal * 0.8f); }, 1); } });
        AddEvent(2, new EN_Event { time = 0.0f, action = () => { Action.Move_Shot(EN_Data.BasePos, eventTime = 0, () => { Action.CreateRotateNomal(RotateNomal_Parent, Blue, new Vector3(-1, -1, -1), new Vector3(1, 0, -1), 5f, 30, EN_Data.EN_BulletSpeed_Nomal, EN_Data.EN_BulletSize_Nomal * 0.8f); }, 1); } });
        AddEvent(2, new EN_Event { time = 0.0f, action = () => { Action.Move_Shot(EN_Data.BasePos, eventTime = 0, () => { Action.CreateRotateNomal(RotateNomal_Parent, Blue, new Vector3(0, 1, -1), new Vector3(0, -1, -1), 5f, 30, EN_Data.EN_BulletSpeed_Nomal, EN_Data.EN_BulletSize_Nomal * 0.8f); }, 1); } });
        AddEvent(2, new EN_Event { time = 0.0f, action = () => { Action.Move_Shot(EN_Data.BasePos, eventTime = 0, () => { Action.CreateRotateNomal(RotateNomal_Parent, Blue, new Vector3(0, -1, -1), new Vector3(0, 1, -1), 5f, 30, EN_Data.EN_BulletSpeed_Nomal, EN_Data.EN_BulletSize_Nomal * 0.8f); }, 1); } });
        AddEvent(2, new EN_Event { time = 1.0f, action = () => { Action.Move_Shot(EN_Data.BasePos, eventTime = 0, () => { StartCoroutine(Action.Straight_Move(EN_Data.BasePos, eventTime = 3f)); }, 1); } });
        AddEvent(2, new EN_Event { time = 1.0f, action = () => { StartCoroutine(Action.Straight_Move(new Vector3(-10f, EN_Data.BasePos.y, EN_Data.BasePos.z), eventTime = 0.5f)); } });
        AddEvent(2, new EN_Event { time = 0.0f, action = () => { Action.Move_Shot(new Vector3(10f, EN_Data.BasePos.y, EN_Data.BasePos.z), eventTime = 1.0f, () => { Action.CreateCircle(Circle_Parent, Blue, EN_Data.EN_BulletSpeed_Nomal, EN_Data.EN_BulletSize_Nomal * 0.8f, 5f, 8, 1.0f, 0.3f); }, 2); } });
        AddEvent(2, new EN_Event { time = 1.0f, action = () => { StartCoroutine(Action.Straight_Move(new Vector3(0f, -10f, EN_Data.BasePos.z), eventTime = 0.5f)); } });
        AddEvent(2, new EN_Event { time = 1.0f, action = () => { Action.Move_Shot(new Vector3(0, 10, EN_Data.BasePos.z), eventTime = 5, () => { Action.CreateFan(Blue, this.transform.forward, EN_Data.EN_BulletSpeed_Low, EN_Data.EN_BulletSize_Nomal * 0.7f, 12, 60); }, 20); } });
        AddEvent(2, new EN_Event { time = 1.0f, action = () => { StartCoroutine(Action.Straight_Move(EN_Data.BasePos, eventTime = 0.5f)); } });
        AddEvent(2, new EN_Event
        {
            time = 3.0f,
            action = () =>
            {
                Action.Move_Shot(EN_Data.BasePos, eventTime = 3f, () =>
                {
                    Action.CreateNomalHoming(Red, new Vector3(0, 0.5f, -1.0f), EN_Data.EN_BulletSpeed_Low, EN_Data.EN_BulletSize_Nomal * 0.8f);
                    Action.CreateNomalHoming(Red, new Vector3(0, -0.5f, -1.0f), EN_Data.EN_BulletSpeed_Low, EN_Data.EN_BulletSize_Nomal * 0.8f);
                    Action.CreateNomalHoming(Red, new Vector3(0.5f, 0, -1.0f), EN_Data.EN_BulletSpeed_Low, EN_Data.EN_BulletSize_Nomal * 0.8f);
                    Action.CreateNomalHoming(Red, new Vector3(-0.5f, 0, -1.0f), EN_Data.EN_BulletSpeed_Low, EN_Data.EN_BulletSize_Nomal * 0.8f);
                }, 20);
            }
        });

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
