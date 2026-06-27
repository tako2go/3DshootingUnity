using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EN_Wave : EN_Bullet
{
    public float amplitude;
    public float frequency;
    public float Rotation;
    private Vector3 OriginPos;
    private Vector3 offset;//回転させる前の中心からのベクトル　←　こいつを回転させて角度を決める
    private float timer = 0;
    // Start is called before the first frame update
    void Start()
    {

        BulletStart();
        OriginPos = this.transform.position;
        BulletVelocity = BulletDir.normalized * EN_BulletSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        WaveMove();
        Bullethit();
        bulletDestroy();
    }

    void WaveMove()
    {
        timer += Time.deltaTime;
        BulletVelocity = BulletDir.normalized * EN_BulletSpeed;
        OriginPos += BulletVelocity * Time.deltaTime;
        offset = Vector3.up * (float)Math.Sin(timer * frequency * 2 * NumericalData.PIE) * amplitude;
        this.transform.position = OriginPos + Quaternion.AngleAxis(Rotation, BulletDir) * offset;
    }
}
