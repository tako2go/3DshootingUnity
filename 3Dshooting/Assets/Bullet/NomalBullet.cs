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
        BulletVelocity = new Vector3(Random.Range(-1, 1), Random.Range(20, 30), Random.Range(1, 2)).normalized * BulletSpeed;

        SetUp();

         downSpeed = 1.5f / (Vector2.Distance(new Vector2(this.transform.position.x, this.transform.position.z), new Vector2(Player.transform.position.x, Player.transform.position.z)) + 0.2f);//1/(x+1)ÇÃä÷êî x = Vector2.dicetance


    }

    // Update is called once per frame
    void Update()
    {
        downSpeed = 1.5f / (Vector2.Distance(new Vector2(this.transform.position.x, this.transform.position.z), new Vector2(Player.transform.position.x, Player.transform.position.z)) + 0.2f);
        homingMove();
        disApp();
    }
}
