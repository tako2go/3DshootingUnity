using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletClass : MonoBehaviour
{
    public float downSpeed;

    public Vector3 StartPosition;

    public float BulletSize;//半径
    public float BulletSpeed;
    float AbsoluteOfAccel = 50;
    public Vector3 BulletVelocity;
    Vector3 accelaration;

    public Transform Player;


    public void SetUp()
    {
        Player = GameObject.FindWithTag("Player").GetComponent<Transform>();
        this.transform.position = StartPosition;
        this.transform.localScale = new Vector3(BulletSize, BulletSize, BulletSize);
    }

    public void homingMove()
    {
        if(this.transform.position.z > Player.transform.position.z)//後ろから追尾はしない　プレイヤーを越したら落下するだけ
        {
            accelaration = new Vector3(Player.transform.position.x - this.transform.position.x, 0, Player.transform.position.z - this.transform.position.z).normalized;
        }
        accelaration = new Vector3(accelaration.x, -downSpeed, accelaration.z);//y軸には常に落下させたい
        BulletVelocity = BulletVelocity.normalized + accelaration * AbsoluteOfAccel * Time.deltaTime;
        //Debug.Log(BulletVelocity.y)
        this.transform.position += BulletVelocity.normalized * BulletSpeed * Time.deltaTime;
    }
    
    public void disApp()//消す
    {
        if(this.transform.position.y <= 0 || this.transform.position.z <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
