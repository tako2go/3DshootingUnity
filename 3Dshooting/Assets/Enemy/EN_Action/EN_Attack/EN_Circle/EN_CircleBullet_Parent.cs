using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class EN_CircleBullet_Parent : MonoBehaviour
{
    //---------フラグ関係---------
    public bool StartShotFlag = false;
    bool shotFlag = false;//現在発射しているか

    //---------circleプロパティ---------
    public int CircleBulletNum;
    public float childBulletSpeed;
    public float childBulletSize;
    public float CircleRadius;
    public float CircleCreateInterval;
    public float CircleShotInterval;
    //---------フラグ関係---------
    public GameObject Bullet;//弾の見た目
    public GameObject[] Bullets;


    // Start is called before the first frame update
    void Start()
    {
        Bullets = new GameObject[CircleBulletNum];
        StartCoroutine(CreateCircleBullet());
    }

    // Update is called once per frame
    void Update()
    {

        if (StartShotFlag)
        {
            StartCoroutine(ShotCircle());
            StartShotFlag = false;
            shotFlag = true;
        }

        if (Bullets[CircleBulletNum - 1] == null && shotFlag)//弾をすべて打ち終え、すべての弾が消えたら
        {
            Destroy(this.gameObject);
        }
    }

    IEnumerator CreateCircleBullet()//敵の周りに弾が円状に少しずつ現れ、一つずつ発射
    {

        for (int i = 0; i < CircleBulletNum; i++)
        {
            Bullets[i] = Instantiate(Bullet, new Vector3(this.transform.position.x + CircleRadius * Mathf.Cos(-((i * 360 * NumericalData.PIE) / (180 * CircleBulletNum)) + NumericalData.PIE / 2), this.transform.position.x + CircleRadius * Mathf.Sin(-((i * 360 * NumericalData.PIE) / (180 * CircleBulletNum)) + NumericalData.PIE / 2), this.transform.position.z), Quaternion.identity, this.transform);
            yield return new WaitForSeconds(CircleCreateInterval);
        }
        StartShotFlag = true;
    }

    IEnumerator ShotCircle()
    {
        Transform Player = GameObject.FindWithTag("Player").GetComponent<Transform>();
        EN_CircleBullet childBullet;
        for (int i = 0; i < CircleBulletNum; i++)
        {
            childBullet = Bullets[i].AddComponent<EN_CircleBullet>();
            childBullet.shot = true;
            childBullet.BulletSize = childBulletSize;
            childBullet.BulletDir = (Player.transform.position - Bullets[i].transform.position);
            childBullet.EN_BulletSpeed = childBulletSpeed;
            yield return new WaitForSeconds(CircleShotInterval);
        }
    }
}
