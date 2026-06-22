using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EN_CircleSimultaneous : EN_AttackClass
{
    // Start is called before the first frame update
    void Start()
    {
        BulletStart();
        BulletVelocity = -this.transform.forward * EN_Data.EN_BulletSpeed_Nomal * Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        // BulletVelocity = BulletDir.normalized * EN_BulletSpeed * Time.deltaTime;
        nomalMove();
        Bullethit();
        bulletDestroy();
    }
}
