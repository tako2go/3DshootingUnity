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
    // Update is called once per frame
    bool Flag = false;
    float timer = 0;

    void Start()
    {
        StartCoroutine(CreateCircleWave(30));
    }

    void Update()
    {

    }

    void CreateNomal()
    {
        Instantiate(NomalBullet, Enemy.transform.position, Quaternion.identity);
    }
    void CreateNomalHoming()
    {
        Instantiate(HomingBullet, Enemy.transform.position, Quaternion.identity);
    }

    void CreateCircleSimultaneousXY(float CircleSimRadius, int CircleSimBulletNum)
    {
        for (int i = 0; i < CircleSimBulletNum; i++)
        {
            GameObject Bullet;
            Bullet = Instantiate(CircleSimBullet, new Vector3(Enemy.transform.position.x + CircleSimRadius * Mathf.Cos(-((i * 360 * NumericalData.PIE) / (180 * CircleSimBulletNum)) + NumericalData.PIE / 2), Enemy.transform.position.x + CircleSimRadius * Mathf.Sin(-((i * 360 * NumericalData.PIE) / (180 * CircleSimBulletNum)) + NumericalData.PIE / 2), Enemy.transform.position.z), Quaternion.identity);
        }
    }

    IEnumerator CreateCircle()
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

    IEnumerator CreateCircleWave(int CircleWaveBulletNum)
    {
        for (int i = 0; i < CircleWaveBulletNum; i++)
        {
            Instantiate(CircleWaveBullet, Enemy.transform.position, Quaternion.identity);
            yield return new WaitForSeconds(NumericalData.CircleWaveCreateInterval);
        }
    }
}
