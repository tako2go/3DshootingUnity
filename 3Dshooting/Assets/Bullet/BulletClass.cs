using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletClass : MonoBehaviour
{
    public float downSpeed;

    public Vector3 StartPosition;

    public float BulletSize;//半径
    public float BulletSpeed;
    public float AbsoluteOfAccel;
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
        const float nonHomingArea = 2.0f;
        //if(this.transform.position.z > Player.transform.position.z)//後ろから追尾はしない　プレイヤーを越したら落下するだけ
        //{
        if(Mathf.Abs(this.transform.position.z - Player.transform.position.z) != -1)
        {
                if(Mathf.Abs(this.transform.position.z - Player.transform.position.z) > nonHomingArea)//追尾させすぎると必ず当たってしまうため範囲を設ける
                {
                    AbsoluteOfAccel = 1.5f / (Mathf.Abs(this.transform.position.z - Player.transform.position.z) - 1f);
                }
        }

        accelaration = (Player.transform.position - this.transform.position) * AbsoluteOfAccel;
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
