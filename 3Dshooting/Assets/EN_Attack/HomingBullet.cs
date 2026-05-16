//using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class HomingBullet : AttackClass
{

    void Start()
    {
        SetUp();
        // StartPosition = new Vector3(Random.Range(-ObjectSizeData.floorX,ObjectSizeData.floorX), Random.Range(0,10),ObjectSizeData.floorY * 2 - 50);

        StartPosition = Enemy.transform.position;
        BulletSize = Random.Range(ObjectSizeData.NomalBulletMin, ObjectSizeData.NomalBulletMax);

        BulletSpeed = Random.Range(50, 100);
        BulletVelocity = new Vector3(Random.Range(-0.5f, 0.5f), Random.Range(0.2f, 0.25f), Random.Range(-2, -1)).normalized * BulletSpeed;

        SetUp();
    }

    // Update is called once per frame
    void Update()
    {
        homingMove();
        Bullethit();
        if (this.transform.position.y <= -ObjectSizeData.MoveBoxY / 2 || this.transform.position.z <= -ObjectSizeData.MoveBoxZ / 2)
        {
            Destroy(this.gameObject);
        }
    }
}
