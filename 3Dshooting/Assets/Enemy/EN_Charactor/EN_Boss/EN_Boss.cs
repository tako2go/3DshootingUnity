using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EN_Boss : Enemy
{
    [SerializeField] GameObject Red;
    [SerializeField] GameObject Blue;


    EN_Manager EN_Manager;
    protected override void Start()
    {
        base.Start();
        new Vector3(UnityEngine.Random.Range(-NumericalData.MoveBoxX / 2, NumericalData.MoveBoxX / 2), UnityEngine.Random.Range(-NumericalData.MoveBoxY / 2, NumericalData.MoveBoxY / 2), EN_Data.BasePos.z);
        EN_HP = 3;
        EN_Manager = GameObject.FindWithTag("EN_Manager").GetComponent<EN_Manager>();
        //----------------------敵行動----------------------
        //書き方:new EN_Event{ time = 前回の行動からの時間,action = () = >{実行する関数};}}
        base.Start();
        new Vector3(UnityEngine.Random.Range(-NumericalData.MoveBoxX / 2, NumericalData.MoveBoxX / 2), UnityEngine.Random.Range(-NumericalData.MoveBoxY / 2, NumericalData.MoveBoxY / 2), EN_Data.BasePos.z);
        EN_HP = 3;
        EN_Manager = GameObject.FindWithTag("EN_Manager").GetComponent<EN_Manager>();
        //----------------------敵行動----------------------
        //書き方:new EN_Event{ time = 実行する時間,action = () = >{実行する関数};}}
        phase = new List<EN_Phase>
        {
            new EN_Phase
            {
                 events = new List<EN_Event>{
        new EN_Event{ time = 1.0f,action = ()=>{Action.Move_Shot(RandomVecto3(), eventTime = 3, () => { Action.CreateNomal(Blue, DirToTarget(Player.transform.position), EN_Data.EN_BulletSpeed_Nomal, 1f); }, 5);}},
        new EN_Event{ time = 1.0f,action = ()=>{Action.Move_Shot(RandomVecto3(), eventTime = 1.5f, () => { Action.CreateNomalHoming(Red, this.transform.forward, EN_Data.EN_BulletSpeed_Nomal, 0.8f); }, 3);}},
        new EN_Event{ time = 1.0f,action = ()=>{Action.Move_Shot(EN_Data.BasePos, eventTime = 3, () => { Action.CreateCircleSimultaneous(Blue, DirToTarget(Player.transform.position), EN_Data.EN_BulletSpeed_Nomal, 1f, 5f, 12);
                                                                                                         Action.CreateCircleSimultaneous(Blue, DirToTarget(Player.transform.position), EN_Data.EN_BulletSpeed_Nomal, 1f, 3f, 6);
                                                                                                         Action.CreateNomal(Blue, DirToTarget(Player.transform.position), EN_Data.EN_BulletSpeed_High, 1f);}, 5);}},
        new EN_Event{ time = 1.0f,action = ()=>{StartCoroutine(Action.Straight_Move(new Vector3(EnableMoveX,Player.transform.position.y,EN_Data.BasePos.z), eventTime = 0.5f));}},
        new EN_Event{ time = 0f,action = ()=>{Action.Move_Shot(new Vector3(-EnableMoveX,this.transform.position.y,EN_Data.BasePos.z), eventTime = 10, () => { Action.CreateNomal(Blue, this.transform.forward, EN_Data.EN_BulletSpeed_Low, 1f); }, 10);}},
        new EN_Event{ time = 1.0f,action = ()=>{Action.Move_Shot(RandomVecto3(), eventTime = 1.5f, () => { Action.CreateFan(Blue, DirToTarget(Player.transform.position) , EN_Data.EN_BulletSpeed_Low, 0.7f, 5, 60);}, 2);}},
        new EN_Event{ time = 1.0f,action = ()=>{StartCoroutine(Action.Straight_Move(new Vector3(-EnableMoveX,Player.transform.position.y,EN_Data.BasePos.z), eventTime = 0.5f));}},
        new EN_Event{ time = 0f,action = ()=>{Action.Move_Shot(new Vector3(EnableMoveX,this.transform.position.y,EN_Data.BasePos.z), eventTime = 10, () => { Action.CreateNomal(Blue, this.transform.forward, EN_Data.EN_BulletSpeed_Low, 1f); }, 10);}},
        new EN_Event{ time = 1.0f,action = ()=>{Action.Move_Shot(RandomVecto3(), eventTime = 1.5f, () => { Action.CreateFan(Blue, DirToTarget(Player.transform.position) , EN_Data.EN_BulletSpeed_Low, 0.7f, 5, 60);}, 2);}},
        new EN_Event{ time = 1.0f,action = ()=>{StartCoroutine(Action.Straight_Move(EN_Data.BasePos, eventTime = 0.5f));}},
        new EN_Event{ time = 1.0f,action = ()=>{Action.Move_Shot(EN_Data.BasePos, eventTime = 3, () => { Action.CreateRotateNomal(Red,Blue, new Vector3(1,-1,-1),new Vector3(-1,1,-1), 5f,10,EN_Data.EN_BulletSpeed_Nomal, 0.8f); }, 1);}},
         }
            },
        new EN_Phase
        {

        }
        };
        eventCount = Random.Range(0, events.Count);//すべての雑魚的が全く同じ動きをするのではなく、開始地点が違う
    }

    protected override void Update()
    {
        base.Update();
        if (EN_HP <= 0)
        {
            Destroy(this.gameObject);
        }
    }




}
