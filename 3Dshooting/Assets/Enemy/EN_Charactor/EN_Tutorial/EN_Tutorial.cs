using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UIElements;

public class EN_Tutorial : MonoBehaviour
{
    public Transform Player;

    //-----------Enemyの行動関係-----------
    bool MoveFlag = false;
    EN_Action Action;
    private List<EN_Tutorial_Event> events;

    //-----------生成するオブジェクト-----------
    public GameObject Red;
    public GameObject Blue;
    private int count = 0;
    private float timer = 0;
    private float eventTime = 0;
    void Start()
    {
        Player = GameObject.FindWithTag("Player").GetComponent<Transform>();

        this.transform.position = EN_Data.BasePos;
        this.transform.rotation = EN_Data.StartRot;
        Action = this.GetComponent<EN_Action>();
        // Action.Move_Shot(new Vector3(10, 10, 20), 5, () => { Action.CreateNomalHoming(Blue, this.transform.forward, EN_Data.EN_BulletSpeed_Nomal, 1f); }, 3);
        //----------------------敵行動----------------------
        events = new List<EN_Tutorial_Event>{
        // new EN_Tutorial_Event{ time = 5f,action = ()=>{Action.Move_Shot(new Vector3(10, 10, 20), eventTime = 5, () => { Action.CreateNomal(Blue, this.transform.forward, EN_Data.EN_BulletSpeed_Nomal, 1f); }, 5);}},
        // new EN_Tutorial_Event{ time = 2f,action = ()=>{Action.Move_Shot(new Vector3(-10, 10, 20), eventTime = 10, () => { Action.CreateNomalHoming(Red, DirToTarget(Player.transform.position), EN_Data.EN_BulletSpeed_High, 0.8f); }, 10);}},
        new EN_Tutorial_Event{ time = 1.5f,action = ()=>{Action.Move_Shot(new Vector3(10, -10, 20), eventTime = 5, () => { Action.CreateCircleSimultaneous(Blue, this.transform.forward, EN_Data.EN_BulletSpeed_Low, 1f, 5f, 12); }, 5);}},
         };

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (count < events.Count)
        {
            if (timer >= events[count].time + eventTime)
            {
                events[count].action?.Invoke();
                count++;
                timer = 0;
            }

        }
    }

    Vector3 DirToTarget(Vector3 Target)
    {
        return Target - this.transform.position;
    }
}
