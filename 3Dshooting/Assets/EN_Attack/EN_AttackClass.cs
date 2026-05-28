using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EN_AttackClass : MonoBehaviour
{
    public float BulletSize;//半径
    public float AbsoluteOfAccel;
    public Vector3 BulletVelocity;
    Vector3 accelaration;

    public Transform Player;
    public Transform Enemy;

    public void BulletStart(float BulletSizeValue)
    {
        Player = GameObject.FindWithTag("Player").GetComponent<Transform>();
        Enemy = GameObject.FindWithTag("Enemy").GetComponent<Transform>();
        BulletSize = BulletSizeValue;
        this.transform.localScale = new Vector3(BulletSizeValue, BulletSizeValue, BulletSizeValue);
    }

    public void nomalMove()
    {
        this.transform.position += BulletVelocity;
    }

    public void homingMove()
    {
        AbsoluteOfAccel = Mathf.Pow(2, -Mathf.Abs(this.transform.position.z - Player.transform.position.z) + 6) + 1;//2^(-x＋〇)+〇
        accelaration = Player.transform.position - this.transform.position;
        BulletVelocity = BulletVelocity.normalized + accelaration.normalized * AbsoluteOfAccel * Time.deltaTime;
        this.transform.position += BulletVelocity.normalized * NumericalData.EN_BulletSpeed * Time.deltaTime;
    }

    public void Bullethit()
    {
        if (Mathf.Abs(this.transform.position.y - Player.transform.position.y) <= NumericalData.playerHeight)
        {
            if (Vector2.Distance(new Vector2(this.transform.position.x, this.transform.position.z), new Vector2(Player.transform.position.x, Player.transform.position.z)) <= BulletSize + NumericalData.playerRadius)
            {
                // Debug.Log("hit");
                Destroy(this.gameObject);
            }
        }
    }
}
