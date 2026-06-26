using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EN_Action : EN_CreateBullet
{

    public void Move_Shot(Vector3 destination, float time, Action ActionFun, int Action_Num)//移動しながら弾を撃つ 引数:(目的地,かける時間,実行する関数,実行する回数(弾数))
    {
        StartCoroutine(Straight_Move(destination, time));
        StartCoroutine(Attack(Action_Num, time, (ActionFun)));
    }

    public IEnumerator Attack(int Action_Num, float time, Action ActionFun)// 引数:(実行する回数(弾数),かける時間,実行する関数)
    {
        if (Action_Num == 1)//弾の発射が一回の時
        {
            yield return new WaitForSeconds(time / 2);
            ActionFun?.Invoke();
        }
        else if (Action_Num > 1)
        {
            float Shot_Interval = time / (Action_Num - 1);
            for (int i = 0; i < Action_Num; i++)
            {
                ActionFun?.Invoke();
                yield return new WaitForSeconds(Shot_Interval);
            }
        }
        else
        {
            yield break;
        }


    }

    public IEnumerator Straight_Move(Vector3 destination, float time)//直線移動 引数:(目的地,かける時間)
    {
        bool MoveFlag;
        float speed = (destination - this.transform.position).magnitude / time;
        Vector3 Velocity = Vector3.zero;
        MoveFlag = ((destination - this.transform.position).sqrMagnitude > EN_Data.destinatonRadius * EN_Data.destinatonRadius);

        while (MoveFlag)
        {
            Velocity = (destination - this.transform.position).normalized * speed * Time.deltaTime;
            this.transform.position += Velocity;
            MoveFlag = ((destination - this.transform.position).sqrMagnitude > EN_Data.destinatonRadius * EN_Data.destinatonRadius);
            yield return new WaitForSeconds(0);//目的地に到達するまで移動
        }
    }
}
