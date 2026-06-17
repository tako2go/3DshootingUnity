//using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class HomingBullet : EN_AttackClass
{

    void Start()
    {
        BulletStart(EN_Data.EN_BulletSize);
        BulletVelocity = new Vector3(Random.Range(-0.5f, 0.5f), Random.Range(0.2f, 0.25f), Random.Range(-2, -1)).normalized * EN_Data.EN_BulletSpeed * Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        homingMove();
        Bullethit();
        if (this.transform.position.y <= -NumericalData.MoveBoxY / 2 || this.transform.position.z <= -NumericalData.MoveBoxZ / 2)
        {
            Destroy(this.gameObject);
        }
    }
}
