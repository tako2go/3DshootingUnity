using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EN_CircleBullet : EN_AttackClass
{
    // Start is called before the first frame update
    public bool shot;
    void Start()
    {
        BulletStart(NumericalData.EN_BulletSize);
    }
    // Update is called once per frame
    void Update()
    {
        if (shot)
        {
            nomalMove();
            Bullethit();
        }
        Debug.Log(shot);
    }
}
