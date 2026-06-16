using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EN_Fan : EN_AttackClass
{
    // Start is called before the first frame update
    void Start()
    {
        BulletStart(NumericalData.EN_BulletSize);
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
