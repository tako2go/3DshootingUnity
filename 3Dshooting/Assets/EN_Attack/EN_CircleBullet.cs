using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EN_CircleBullet : EN_NomalBullet
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        nomalMove();
        Bullethit();
    }
}
