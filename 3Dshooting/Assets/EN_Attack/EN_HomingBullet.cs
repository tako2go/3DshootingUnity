//using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class HomingBullet : EN_AttackClass
{

    void Start()
    {
        Player = GameObject.FindWithTag("Player").GetComponent<Transform>();
        Enemy = GameObject.FindWithTag("Enemy").GetComponent<Transform>();

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
