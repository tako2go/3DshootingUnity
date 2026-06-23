using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEditor.TestTools.CodeCoverage;
using UnityEngine;

public class EN_Mob : Enemy
{
    // Start is called before the first frame update
    [SerializeField] GameObject Red;
    [SerializeField] GameObject Blue;

    private float EnableMoveX = NumericalData.MoveBoxX / 2;//移動範囲
    private float EnableMoveY = NumericalData.MoveBoxY / 2;

    protected override void Start()
    {
        base.Start();
        EN_HP = 3;        //----------------------敵行動----------------------
        //書き方:new EN_Event{ time = 前回の行動からの時間,action = () = >{実行する関数};}}
        events = new List<EN_Event>{
        new EN_Event{ time = 1.0f,action = ()=>{Action.Move_Shot(RandomVecto3(), eventTime = 3, () => { Action.CreateNomal(Blue, DirToTarget(Player.transform.position), EN_Data.EN_BulletSpeed_Nomal, 1f); }, 5);}},
        new EN_Event{ time = 1.0f,action = ()=>{Action.Move_Shot(RandomVecto3(), eventTime = 1.5f, () => { Action.CreateNomalHoming(Red, this.transform.forward, EN_Data.EN_BulletSpeed_Nomal, 0.8f); }, 10);}},
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
         };
        count = Random.Range(0, events.Count);//すべての雑魚的が全く同じ動きをするのではなく、開始地点が違う
    }


    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= events[count].time + eventTime)
        {
            events[count].action?.Invoke();
            timer = 0;
            count++;
            if (count >= events.Count)
            {
                count = Random.Range(0, events.Count);
            }

        }
    }

    Vector3 DirToTarget(Vector3 Target)
    {
        return Target - this.transform.position;
    }

    Vector3 RandomVecto3()
    {
        return new Vector3(Random.Range(-EnableMoveX, EnableMoveX), Random.Range(-EnableMoveY, EnableMoveY), EN_Data.BasePos.z);//移動可能範囲内でランダムな位置を生成
    }
}
