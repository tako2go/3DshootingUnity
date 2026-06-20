using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EN_Tutorial : MonoBehaviour
{
    public Transform Player;

    bool MoveFlag = false;
    EN_Action_Tutorial Action;

    //-----------生成するオブジェクト-----------
    public GameObject Red;
    public GameObject Blue;


    void Start()
    {
        Player = GameObject.FindWithTag("Player").GetComponent<Transform>();
        this.transform.position = EN_Data.BasePos;
        this.transform.rotation = EN_Data.StartRot;
        Action = this.GetComponent<EN_Action_Tutorial>();
        Action.Move_Shot(new Vector3(10, 10, 20), 5, () => { Action.CreateNomal(Red, Player.transform.position - this.transform.position, 15f, 1.0f); }, 5);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
