using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NomalBullet : AttackClass
{
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindWithTag("Player").GetComponent<Transform>();
        Enemy = GameObject.FindWithTag("Enemy").GetComponent<Transform>();
        StartPosition = Enemy.transform.position;
        BulletSize = Random.Range(ObjectSizeData.NomalBulletMin, ObjectSizeData.NomalBulletMax);
        BulletSpeed = Random.Range(50, 100);
        BulletVelocity = (Player.transform.position - StartPosition).normalized * BulletSpeed;//この時点でthis.transform.positionは正式な値になっていないためStartPositionを使用
        SetUp();
    }

    // Update is called once per frame
    void Update()
    {
        nomalMove();
        Bullethit();
        if (this.transform.position.y <= -ObjectSizeData.MoveBoxY / 2 || this.transform.position.z <= -ObjectSizeData.MoveBoxZ / 2)
        {
            Destroy(this.gameObject);
        }
    }
}
