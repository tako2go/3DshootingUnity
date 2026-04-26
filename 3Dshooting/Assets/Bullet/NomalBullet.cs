//using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class NomalBullet : BulletClass
{

    void Start()
    {
        StartPosition = new Vector3(Random.Range(-ObjectSizeData.floorX,ObjectSizeData.floorX), Random.Range(0,10),ObjectSizeData.floorY - 50);

        BulletSize = Random.Range(ObjectSizeData.NomalBulletMin, ObjectSizeData.NomalBulletMax);

        BulletSpeed = Random.Range(30,80);

        SetUp();
    }

    // Update is called once per frame
    void Update()
    {
        move();
        disApp();
    }
}
