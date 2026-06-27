using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class EN_CreateBullet : MonoBehaviour
{


    public void CreateNomal(GameObject BulletType, Vector3 directon, float Speed, float size)//まっすぐ飛ぶ
    {
        GameObject NomalBullet = Instantiate(BulletType, this.transform.position, Quaternion.identity);
        EN_NomalBullet bullet = NomalBullet.AddComponent<EN_NomalBullet>();
        bullet.BulletDir = directon;
        bullet.EN_BulletSpeed = Speed;
        bullet.BulletSize = size;
    }

    public void CreateRotateNomal(GameObject ParentType, GameObject BulletType, Vector3 Start_directon, Vector3 end_direction, float time, int bulletNum, float Speed, float size)//角度を変えながら撃つ
    {
        GameObject RotateNomal_Parent = Instantiate(ParentType, this.transform.position, Quaternion.identity);
        EN_RotateNomal_parent parent = RotateNomal_Parent.AddComponent<EN_RotateNomal_parent>();
        parent.Bullet = BulletType;
        parent.childBulletSpeed = Speed;
        parent.childBulletSize = size;
        parent.Start_directon = Start_directon;
        parent.end_direction = end_direction;
        parent.execution_time = time;
        parent.BulletNum = bulletNum;
    }

    public void CreateNomalHoming(GameObject BulletType, Vector3 directon, float Speed, float size)//追尾する
    {
        GameObject HomingBullet = Instantiate(BulletType, this.transform.position, Quaternion.identity);
        EN_HomingBullet bullet = HomingBullet.AddComponent<EN_HomingBullet>();
        bullet.BulletDir = directon;//最初の方向
        bullet.EN_BulletSpeed = Speed;
        bullet.BulletSize = size;
    }

    public void CreateCircleSimultaneous(GameObject BulletType, Vector3 directon, float Speed, float size, float CircleSimRadius, int CircleSimBulletNum)//一瞬で敵の周りに円状に弾が複数現れ、同時に発射
    {
        for (int i = 0; i < CircleSimBulletNum; i++)
        {
            GameObject CircleSimultaneousXY = Instantiate(BulletType, new Vector3(this.transform.position.x + CircleSimRadius * Mathf.Cos(-((i * 360 * NumericalData.PIE) / (180 * CircleSimBulletNum)) + NumericalData.PIE / 2), this.transform.position.y + CircleSimRadius * Mathf.Sin(-((i * 360 * NumericalData.PIE) / (180 * CircleSimBulletNum)) + NumericalData.PIE / 2), this.transform.position.z), Quaternion.identity);
            EN_CircleSimultaneous bullet = CircleSimultaneousXY.AddComponent<EN_CircleSimultaneous>();
            bullet.BulletDir = directon;
            bullet.EN_BulletSpeed = Speed;
            bullet.BulletSize = size;
        }
    }

    public void CreateCircle(GameObject Parenttype, GameObject BulletType, float Speed, float size, float Radius, int BulletNum, float CreateInterval, float shotInterval)
    {
        GameObject CircleParent = Instantiate(Parenttype, this.transform.position, Quaternion.identity);
        EN_CircleBullet_Parent parent = CircleParent.AddComponent<EN_CircleBullet_Parent>();
        parent.Bullet = BulletType;
        parent.childBulletSpeed = Speed;
        parent.childBulletSize = size;
        parent.CircleRadius = Radius;
        parent.CircleBulletNum = BulletNum;
        parent.CircleCreateInterval = CreateInterval;
        parent.CircleShotInterval = shotInterval;
    }

    public void CreateSpin(GameObject BulletType, Vector3 directon, float Speed, float size, float RotSpeed, float WaveRadius)
    {
        GameObject CircleWaveBullet = Instantiate(BulletType, this.transform.position, Quaternion.identity);
        EN_Spin bullet = CircleWaveBullet.AddComponent<EN_Spin>();
        bullet.BulletDir = directon;
        bullet.EN_BulletSpeed = Speed;
        bullet.BulletSize = size;
        bullet.RotateSpeed = RotSpeed;
        bullet.CircleWaveRadius = WaveRadius;
        Debug.Log("作成したよ！");
    }

    public void CreateFan(GameObject BulletType, Vector3 directon, float Speed, float size, int bulletNum, float CneterDegree)//敵の位置から扇形のようにX-Z平面上に複数の弾が発射
    {
        float StartAngle = -CneterDegree / 2;//最初の発射方向
        float StepAngle = CneterDegree / (bulletNum - 1);//弾を何度ずつ発射するか

        for (int i = 0; i < bulletNum; i++)
        {
            GameObject FanBullet = Instantiate(BulletType, this.transform.position, Quaternion.identity);
            EN_Fan Bullet = FanBullet.AddComponent<EN_Fan>();
            Bullet.BulletSize = size;
            Bullet.BulletDir = (Quaternion.AngleAxis(StartAngle + StepAngle * i, Vector3.up) * directon.normalized);
            Bullet.EN_BulletSpeed = Speed;
            // Debug.Log(i + ":" + Quaternion.AngleAxis(StartAngle + StepAngle * i, Vector3.up) * this.transform.forward);
        }
    }
}
