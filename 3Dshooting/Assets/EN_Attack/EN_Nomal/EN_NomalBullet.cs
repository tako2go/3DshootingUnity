using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EN_NomalBullet : EN_AttackClass
{
    // Start is called before the first frame update
    protected virtual void Start()
    {
        Player = GameObject.FindWithTag("Player").GetComponent<Transform>();
        Enemy = GameObject.FindWithTag("Enemy").GetComponent<Transform>();
        // BulletSize = Random.Range(ObjectSizeData.NomalBulletMin, ObjectSizeData.NomalBulletMax);
        BulletSize = NumericalData.BulletSize;
        BulletSpeed = Random.Range(50, 100);
        BulletVelocity = (Player.transform.position - this.transform.position).normalized * BulletSpeed;
        SetUp();
    }

    // Update is called once per frame
    void Update()
    {
        nomalMove();
        Bullethit();
        if (this.transform.position.y <= -NumericalData.MoveBoxY / 2 || this.transform.position.z <= -NumericalData.MoveBoxZ / 2)
        {
            Destroy(this.gameObject);
        }
    }
}
