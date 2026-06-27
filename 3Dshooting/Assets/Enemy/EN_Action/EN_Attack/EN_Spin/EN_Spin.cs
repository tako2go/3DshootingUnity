using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EN_Spin : EN_Bullet
{
    // Start is called before the first frame update


    private Vector3 CenterPos;//弾が進む中心軸
    public float RotateSpeed;//回転スピード
    public float CircleWaveRadius;//回転半径

    private float Angle = 0;//回転角度


    void Start()
    {
        BulletStart();
        CenterPos = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        circleWaveMove();
        Bullethit();
        bulletDestroy();
    }

    void circleWaveMove()
    {
        BulletVelocity = BulletDir.normalized * EN_BulletSpeed;
        CenterPos += BulletVelocity * Time.deltaTime;
        Angle += RotateSpeed * Time.deltaTime;
        Vector3 offset = Quaternion.AngleAxis(Angle, BulletDir.normalized) * Vector3.Cross(BulletDir, transform.up).normalized * CircleWaveRadius;
        //　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　↑
        //                              Vector3.Cross(BulletDir, transform.up):外積計算　BulletDirに垂直なベクトル
        transform.position = CenterPos + offset;
    }
}
