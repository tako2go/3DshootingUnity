using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class EN_CreateBullet : MonoBehaviour
{
    // Start is called before the first frame update

    // public GameObject NomalBullet;
    // public GameObject HomingBullet;
    // public GameObject CircleBullet;
    // public GameObject CircleSimBullet;
    // public GameObject CircleWaveBullet;
    // public GameObject FanBullet;



    public void CreateNomal(GameObject BulletType, Vector3 directon, float Speed, float size)//まっすぐ飛ぶ
    {
        GameObject NomalBullet = Instantiate(BulletType, this.transform.position, Quaternion.identity);
        EN_NomalBullet bullet = NomalBullet.AddComponent<EN_NomalBullet>();
        bullet.BulletDir = directon;
        bullet.EN_BulletSpeed = Speed;
        bullet.BulletSize = size;
    }
    public void CreateNomalHoming(GameObject BulletType, Vector3 directon, float Speed, float size)//追尾する
    {
        GameObject HomingBullet = Instantiate(BulletType, this.transform.position, Quaternion.identity);
        EN_HomingBullet bullet = HomingBullet.AddComponent<EN_HomingBullet>();
        bullet.BulletDir = directon;//最初の方向
        bullet.EN_BulletSpeed = Speed;
        bullet.BulletSize = size;
    }

    public void CreateCircleSimultaneousXY(GameObject BulletType, float CircleSimRadius, int CircleSimBulletNum)//一瞬で敵の周りに円状に弾が複数現れ、同時に発射
    {
        for (int i = 0; i < CircleSimBulletNum; i++)
        {
            // GameObject Bullet;
            // Bullet = Instantiate(CircleSimBullet, new Vector3(this.transform.position.x + CircleSimRadius * Mathf.Cos(-((i * 360 * NumericalData.PIE) / (180 * CircleSimBulletNum)) + NumericalData.PIE / 2), this.transform.position.x + CircleSimRadius * Mathf.Sin(-((i * 360 * NumericalData.PIE) / (180 * CircleSimBulletNum)) + NumericalData.PIE / 2), this.transform.position.z), Quaternion.identity);
            GameObject CircleSimultaneousXY = Instantiate(BulletType, new Vector3(this.transform.position.x + CircleSimRadius * Mathf.Cos(-((i * 360 * NumericalData.PIE) / (180 * CircleSimBulletNum)) + NumericalData.PIE / 2), this.transform.position.x + CircleSimRadius * Mathf.Sin(-((i * 360 * NumericalData.PIE) / (180 * CircleSimBulletNum)) + NumericalData.PIE / 2), this.transform.position.z), Quaternion.identity);
            CircleSimultaneousXY.AddComponent<EN_CircleSimultaneousXY>();
        }
    }

    public void CreateCircle(GameObject BulletType, GameObject Parenttype)
    {
        GameObject CircleParent = Instantiate(Parenttype, this.transform.position, Quaternion.identity);
        EN_CircleBullet_Parent parent = CircleParent.AddComponent<EN_CircleBullet_Parent>();
        parent.Bullet = BulletType;
    }

    // IEnumerator CreateCircleWave(int CircleWaveBulletNum)//複数の弾が波のように円を描きながら迫ってくる
    // {
    //     for (int i = 0; i < CircleWaveBulletNum; i++)
    //     {
    //         Instantiate(CircleWaveBullet, Enemy.transform.position, Quaternion.identity);
    //         yield return new WaitForSeconds(NumericalData.CircleWaveCreateInterval);
    //     }
    // }

    public void CreateCircleWave(GameObject BulletType)
    {
        GameObject CircleWaveBullet = Instantiate(BulletType, this.transform.position, Quaternion.identity);
        CircleWaveBullet.AddComponent<EN_CircleWave>();
    }

    public void CreateFan(GameObject BulletType, int bulletNum, float CneterDegree)//敵の位置から扇形のようにX-Z平面上に複数の弾が発射
    {
        float StartAngle = -CneterDegree / 2;//最初の発射方向
        float StepAngle = CneterDegree / (bulletNum - 1);//弾を何度ずつ発射するか

        for (int i = 0; i < bulletNum; i++)
        {
            GameObject FanBullet = Instantiate(BulletType, this.transform.position, Quaternion.identity);
            EN_Fan Bullet = FanBullet.AddComponent<EN_Fan>();
            Bullet.BulletVelocity = (Quaternion.AngleAxis(StartAngle + StepAngle * i, Vector3.up) * this.transform.forward) * EN_Data.EN_BulletSpeed * Time.deltaTime;
            // Debug.Log(i + ":" + Quaternion.AngleAxis(StartAngle + StepAngle * i, Vector3.up) * this.transform.forward);
        }
    }
}
