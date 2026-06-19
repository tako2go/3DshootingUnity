using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EN_NomalBullet : EN_AttackClass
{
    // Start is called before the first frame update
    void Start()
    {
        BulletStart(EN_Data.EN_BulletSize);
    }

    // Update is called once per frame
    void Update()
    {
        BulletVelocity = Enemy.transform.forward * EN_Data.EN_BulletSpeed * Time.deltaTime;
        nomalMove();
        Bullethit();
        bulletDestroy();
    }
}
