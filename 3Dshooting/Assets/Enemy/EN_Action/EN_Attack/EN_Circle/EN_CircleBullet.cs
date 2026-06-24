using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class EN_CircleBullet : EN_Bullet
{
    // Start is called before the first frame update
    public bool shot;
    void Start()
    {
        BulletStart();
    }
    // Update is called once per frame
    void Update()
    {
        if (shot)
        {
            BulletVelocity = BulletDir.normalized * EN_BulletSpeed * Time.deltaTime;
            nomalMove();
            Bullethit();
            bulletDestroy();
        }
    }
}
