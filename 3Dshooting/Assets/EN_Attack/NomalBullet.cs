using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NomalBullet : AttackClass
{
    // Start is called before the first frame update
    void Start()
    {
        SetUp();
        StartPosition = Enemy.transform.position;
        BulletSize = Random.Range(ObjectSizeData.NomalBulletMin, ObjectSizeData.NomalBulletMax);

        BulletSpeed = Random.Range(50, 100);
        BulletVelocity = (Player.transform.position - this.transform.position).normalized * BulletSpeed;
        SetUp();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
