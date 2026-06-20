using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EN_CircleSimultaneous : EN_AttackClass
{
    // Start is called before the first frame update
    void Start()
    {
        BulletStart(EN_Data.EN_BulletSize);
        BulletVelocity = BulletDir.normalized * EN_BulletSpeed * Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        nomalMove();
        Bullethit();
        bulletDestroy();
    }
}
