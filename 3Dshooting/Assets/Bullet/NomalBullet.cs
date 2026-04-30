//using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class NomalBullet : BulletClass
{

    void Start()
    {

        SetUp();

        StartPosition = new Vector3(Random.Range(-ObjectSizeData.floorX,ObjectSizeData.floorX), Random.Range(0,10),ObjectSizeData.floorY * 2 - 50);

        BulletSize = Random.Range(ObjectSizeData.NomalBulletMin, ObjectSizeData.NomalBulletMax);

        BulletSpeed = Random.Range(50,100);
        BulletVelocity = new Vector3(Random.Range(-0.1f, 0.1f), Random.Range(0.2f, 0.25f), Random.Range(-2, -1)).normalized * BulletSpeed;

        SetUp();
    }

    // Update is called once per frame
    void Update()
    {
        homingMove();
        hit();
        if (this.transform.position.y <= 0 || this.transform.position.z <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
