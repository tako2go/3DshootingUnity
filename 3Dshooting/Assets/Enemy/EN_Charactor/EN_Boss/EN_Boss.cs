using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EN_Boss : Enemy
{
    [SerializeField] GameObject Red;
    [SerializeField] GameObject Blue;

    private float EnableMoveX = NumericalData.MoveBoxX / 2;//移動範囲
    private float EnableMoveY = NumericalData.MoveBoxY / 2;

    EN_Manager EN_Manager;
    protected override void Start()
    {
        base.Start();
        new Vector3(UnityEngine.Random.Range(-NumericalData.MoveBoxX / 2, NumericalData.MoveBoxX / 2), UnityEngine.Random.Range(-NumericalData.MoveBoxY / 2, NumericalData.MoveBoxY / 2), EN_Data.BasePos.z);
        EN_HP = 3;
        EN_Manager = GameObject.FindWithTag("EN_Manager").GetComponent<EN_Manager>();
        //----------------------敵行動----------------------
        //書き方:new EN_Event{ time = 前回の行動からの時間,action = () = >{実行する関数};}}
        events = new List<EN_Event>
        {

        };
        count = Random.Range(0, events.Count);//すべての雑魚的が全く同じ動きをするのではなく、開始地点が違う
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
