using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EN_CircleBullet_Parent : MonoBehaviour
{
    public bool StartShotFlag = false;
    bool shotFlag = false;//現在発射しているか
    public GameObject Bullet;
    public GameObject[] Bullets = new GameObject[EN_Data.CircleBulletNum];

    // Start is called before the first frame update
    void Start()
    {
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

        if (Bullets[EN_Data.CircleBulletNum - 1] == null && shotFlag)//弾をすべて打ち終え、すべての弾が消えたら
        {
            Destroy(this.gameObject);
        }
    }

    IEnumerator CreateCircleBullet()//敵の周りに弾が円状に少しずつ現れ、一つずつ発射
    {

        for (int i = 0; i < EN_Data.CircleBulletNum; i++)
        {
            Bullets[i] = Instantiate(Bullet, new Vector3(this.transform.position.x + EN_Data.CircleRadius * Mathf.Cos(-((i * 360 * NumericalData.PIE) / (180 * EN_Data.CircleBulletNum)) + NumericalData.PIE / 2), this.transform.position.x + EN_Data.CircleRadius * Mathf.Sin(-((i * 360 * NumericalData.PIE) / (180 * EN_Data.CircleBulletNum)) + NumericalData.PIE / 2), this.transform.position.z), Quaternion.identity, this.transform);
            yield return new WaitForSeconds(EN_Data.CircleCreateInterval);
        }
        StartShotFlag = true;
    }

    IEnumerator ShotCircle()
    {
        Transform Player = GameObject.FindWithTag("Player").GetComponent<Transform>();
        EN_CircleBullet childBullet;
        for (int i = 0; i < EN_Data.CircleBulletNum; i++)
        {
            childBullet = Bullets[i].AddComponent<EN_CircleBullet>();
            childBullet.shot = true;
            childBullet.BulletVelocity = (Player.transform.position - Bullets[i].transform.position).normalized * EN_Data.EN_BulletSpeed * Time.deltaTime;
            yield return new WaitForSeconds(EN_Data.CircleShotInterval);
        }
    }
}
