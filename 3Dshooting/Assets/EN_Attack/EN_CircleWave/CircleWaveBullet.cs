using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleWaveBullet : EN_AttackClass
{
    // Start is called before the first frame update

    private Vector3 RunDir;
    private Vector3 RorateDir;

    private Vector3 CenterPos;

    private float Angle = 0;
    private float RotateSpeed = 800;

    private float timer = 0;
    void Start()
    {
        BulletStart(EN_Data.EN_BulletSize);
        BulletVelocity = -this.transform.forward * EN_Data.EN_BulletSpeed / 3 * Time.deltaTime;
        CenterPos = this.transform.position;
        RunDir = Enemy.transform.forward;
        RorateDir = Enemy.transform.right;
    }

    // Update is called once per frame
    void Update()
    {
        circleWaveMove();
        Bullethit();
        if (this.transform.position.y <= -NumericalData.MoveBoxY / 2 || this.transform.position.z <= -NumericalData.MoveBoxZ / 2)
        {
            Destroy(this.gameObject);
        }
    }

    void circleWaveMove()
    {
        CenterPos += BulletVelocity;
        Angle += RotateSpeed * Time.deltaTime;
        Vector3 offset = Quaternion.AngleAxis(Angle, RunDir) * transform.right * EN_Data.CircleWaveRadius;
        transform.position = CenterPos + offset;
    }
}
