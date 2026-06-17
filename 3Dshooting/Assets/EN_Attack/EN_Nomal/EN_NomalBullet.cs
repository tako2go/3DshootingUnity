using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EN_NomalBullet : EN_AttackClass
{
    // Start is called before the first frame update
    void Start()
    {
        BulletStart(EN_Data.EN_BulletSize);
        BulletVelocity = (Player.transform.position - this.transform.position).normalized * EN_Data.EN_BulletSpeed * Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        // nomalMove();
        Bullethit();
        if (this.transform.position.y <= -NumericalData.MoveBoxY / 2 || this.transform.position.z <= -NumericalData.MoveBoxZ / 2)
        {
            Destroy(this.gameObject);
        }
    }
}
