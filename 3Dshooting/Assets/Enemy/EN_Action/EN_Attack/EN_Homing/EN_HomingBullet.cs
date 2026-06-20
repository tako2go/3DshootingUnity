//using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class EN_HomingBullet : EN_AttackClass
{

    void Start()
    {
        BulletStart();
        // BulletVelocity = new Vector3(Random.Range(-0.1f, 0.1f), Random.Range(0.5f, 0.75f), Random.Range(-2, -1)).normalized * EN_Data.EN_BulletSpeed * Time.deltaTime;
        BulletVelocity = BulletDir.normalized * EN_BulletSpeed * Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        homingMove();
        Bullethit();
        bulletDestroy();
    }
}
