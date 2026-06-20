using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EN_AttackClass : MonoBehaviour
{
    public float BulletSize;//半径
    public float AbsoluteOfAccel;//ホーミング弾の加速度の大きさ
    public Vector3 BulletVelocity;//弾の速度
    public Vector3 BulletDir;//弾の方向
    public float EN_BulletSpeed;
    Vector3 accelaration;

    public Transform Player;
    public Transform Enemy;
    float tiemr = 0;

    public void BulletStart(float BulletSizeValue)
    {
        Player = GameObject.FindWithTag("Player").GetComponent<Transform>();
        Enemy = GameObject.FindWithTag("Enemy").GetComponent<Transform>();
        this.transform.localScale = new Vector3(BulletSizeValue * 2, BulletSizeValue * 2, BulletSizeValue * 2);//直径に変換するために*2
    }

    public void nomalMove()
    {
        this.transform.position += BulletVelocity;
    }

    public void homingMove()
    {
        if ((this.transform.position.z - Player.transform.position.z) >= EN_Data.HomingDistance)//弾がプレイヤーに対しホーミング可能距離より離れていたら
        {
            AbsoluteOfAccel = (Mathf.Pow(2, -Mathf.Abs(this.transform.position.z - Player.transform.position.z) + 3) + 0) * 0.1f;//(2^(-x＋〇グラフ右ずらし)+〇グラフ上上げ)*〇グラフ縦圧縮
            accelaration = Player.transform.position - this.transform.position;
            BulletVelocity = BulletVelocity.normalized + accelaration.normalized * AbsoluteOfAccel;
        }

        this.transform.position += BulletVelocity.normalized * EN_Data.EN_BulletSpeed * Time.deltaTime;
    }

    public void Bullethit()
    {
        if (Mathf.Abs(this.transform.position.y - Player.transform.position.y) <= PL_Data.PL_Height + BulletSize)
        {
            if ((new Vector2(this.transform.position.x, this.transform.position.z) - new Vector2(Player.transform.position.x, Player.transform.position.z)).sqrMagnitude <= (BulletSize + PL_Data.PL_Radius) * (BulletSize + PL_Data.PL_Radius))
            {
                Destroy(this.gameObject);
            }
        }
    }

    public void bulletDestroy()//指定の範囲から出たら削除
    {
        tiemr += Time.deltaTime;
        if ((this.transform.position.y <= (-NumericalData.MoveBoxY / 2) * 1.5f || this.transform.position.z <= (-NumericalData.MoveBoxZ / 2) * 1.5f) || tiemr >= 30f)
        {
            Destroy(this.gameObject);
        }
    }
}
