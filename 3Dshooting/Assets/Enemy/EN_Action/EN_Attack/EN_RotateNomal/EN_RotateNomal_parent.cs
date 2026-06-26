using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EN_RotateNomal_parent : MonoBehaviour
{
    //---------RotateNomalプロパティ---------
    public int BulletNum;
    public Vector3 Start_directon;
    public Vector3 end_direction;
    public float execution_time;//実行する全体の時間
    public float childBulletSpeed;
    public float childBulletSize;
    private bool BulletFlag = false;//すべての子オブジェクトがNullだとfalse
    private bool ShotFlag = false;//一発でも発射したらtrue
    //---------フラグ関係---------
    public GameObject Bullet;//弾の見た目
    public GameObject[] Bullets;
    void Start()
    {
        StartCoroutine(shot_RotateNomal());
    }

    // Update is called once per frame
    void Update()
    {
        if (ShotFlag)
        {
            BulletFlag = false;
            for (int i = 0; i < BulletNum; i++)
            {
                if (Bullets[i] != null)
                {
                    BulletFlag = true;
                }
            }
        }
        if (BulletFlag == false)
        {
            Destroy(this.gameObject);
        }
    }

    IEnumerator shot_RotateNomal()
    {
        Transform Player = GameObject.FindWithTag("Player").GetComponent<Transform>();
        EN_NomalBullet childBullet;
        Bullets = new GameObject[BulletNum];
        for (int i = 0; i < BulletNum; i++)
        {
            Bullets[i] = Instantiate(Bullet, this.transform.position, Quaternion.identity, this.transform);
            childBullet = Bullets[i].AddComponent<EN_NomalBullet>();
            childBullet.BulletSize = childBulletSize;
            childBullet.BulletDir = Vector3.Lerp(Start_directon, end_direction, (float)i / BulletNum).normalized;
            childBullet.EN_BulletSpeed = childBulletSpeed;
            ShotFlag = true;
            yield return new WaitForSeconds(execution_time / BulletNum);
        }
    }
}
