using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class EN_CreateBullet : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform Enemy;
    public GameObject NomalBullet;
    public GameObject HomingBullet;
    public GameObject CircleBullet;
    public GameObject CircleSimBullet;
    public GameObject CircleWaveBullet;
    public GameObject FanBullet;
    // Update is called once per frame
    bool Flag = false;
    float timer = 0;

    void Start()
    {
        // StartCoroutine(CreateCircleWave(30));

    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 0.5f)
        {
            // CreateFan(11, 100);
            CreateCircleWave();
            timer = 0;
        }

    }


    void CreateNomal()//まっすぐ飛ぶ
    {
        Instantiate(NomalBullet, Enemy.transform.position, Quaternion.identity);
    }
    void CreateNomalHoming()//追尾する
    {
        Instantiate(HomingBullet, Enemy.transform.position, Quaternion.identity);
    }

    void CreateCircleSimultaneousXY(float CircleSimRadius, int CircleSimBulletNum)//一瞬で敵の周りに円状に弾が複数現れ、同時に発射
    {
        for (int i = 0; i < CircleSimBulletNum; i++)
        {
            // GameObject Bullet;
            // Bullet = Instantiate(CircleSimBullet, new Vector3(Enemy.transform.position.x + CircleSimRadius * Mathf.Cos(-((i * 360 * NumericalData.PIE) / (180 * CircleSimBulletNum)) + NumericalData.PIE / 2), Enemy.transform.position.x + CircleSimRadius * Mathf.Sin(-((i * 360 * NumericalData.PIE) / (180 * CircleSimBulletNum)) + NumericalData.PIE / 2), Enemy.transform.position.z), Quaternion.identity);
            Instantiate(CircleSimBullet, new Vector3(Enemy.transform.position.x + CircleSimRadius * Mathf.Cos(-((i * 360 * NumericalData.PIE) / (180 * CircleSimBulletNum)) + NumericalData.PIE / 2), Enemy.transform.position.x + CircleSimRadius * Mathf.Sin(-((i * 360 * NumericalData.PIE) / (180 * CircleSimBulletNum)) + NumericalData.PIE / 2), Enemy.transform.position.z), Quaternion.identity);
        }
    }

    IEnumerator CreateCircle()//敵の周りに弾が円状に少しずつ現れ、一つずつ発射
    {
        GameObject CircleParent = new GameObject("CircleParent");
        EN_CircleBullet_Parent ParentScript = CircleParent.AddComponent<EN_CircleBullet_Parent>();

        for (int i = 0; i < NumericalData.CircleBulletNum; i++)
        {
            ParentScript.Bullets[i] = Instantiate(CircleBullet, new Vector3(Enemy.transform.position.x + NumericalData.CircleRadius * Mathf.Cos(-((i * 360 * NumericalData.PIE) / (180 * NumericalData.CircleBulletNum)) + NumericalData.PIE / 2), Enemy.transform.position.x + NumericalData.CircleRadius * Mathf.Sin(-((i * 360 * NumericalData.PIE) / (180 * NumericalData.CircleBulletNum)) + NumericalData.PIE / 2), Enemy.transform.position.z), Quaternion.identity, CircleParent.transform);
            yield return new WaitForSeconds(NumericalData.CircleCreateInterval);
        }
        ParentScript.StartShot = true;
    }

    // IEnumerator CreateCircleWave(int CircleWaveBulletNum)//複数の弾が波のように円を描きながら迫ってくる
    // {
    //     for (int i = 0; i < CircleWaveBulletNum; i++)
    //     {
    //         Instantiate(CircleWaveBullet, Enemy.transform.position, Quaternion.identity);
    //         yield return new WaitForSeconds(NumericalData.CircleWaveCreateInterval);
    //     }
    // }

    void CreateCircleWave()
    {
        Instantiate(CircleWaveBullet, Enemy.transform.position, Quaternion.identity);
    }

    void CreateFan(int bulletNum, float CneterDegree)//敵の位置から扇形のようにX-Z平面上に複数の弾が発射
    {
        float StartAngle = -CneterDegree / 2;//最初の発射方向
        float StepAngle = CneterDegree / (bulletNum - 1);//弾を何度ずつ発射するか
        for (int i = 0; i < bulletNum; i++)
        {
            EN_Fan Bullet = Instantiate(FanBullet, Enemy.transform.position, Quaternion.identity).GetComponent<EN_Fan>();
            Bullet.BulletVelocity = (Quaternion.AngleAxis(StartAngle + StepAngle * i, Vector3.up) * Enemy.transform.forward) * NumericalData.EN_BulletSpeed * Time.deltaTime;
            Debug.Log(i + ":" + Quaternion.AngleAxis(StartAngle + StepAngle * i, Vector3.up) * Enemy.transform.forward);
        }
    }
}
