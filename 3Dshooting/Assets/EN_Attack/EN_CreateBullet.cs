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

    // Update is called once per frame
    bool Flag = false;
    void Update()
    {

        if (!Flag)
        {
            StartCoroutine(CreateCircle());
            Flag = true;
        }
    }

    void CreateNomal()
    {
        Instantiate(NomalBullet, Enemy.transform.position, Quaternion.identity);
    }
    void CreateNomalHoming()
    {
        Instantiate(HomingBullet, Enemy.transform.position, Quaternion.identity);
    }

    IEnumerator CreateCircle()
    {
        GameObject Parent = new GameObject("CircleParent");
        EN_CircleBullet_Parent ParentScript = Parent.AddComponent<EN_CircleBullet_Parent>();

        for (int i = 0; i < NumericalData.CircleBulletNum; i++)
        {
            ParentScript.Bullets[i] = Instantiate(CircleBullet, new Vector3(Enemy.transform.position.x + NumericalData.CircleRadius * Mathf.Cos(-((i * 360 * NumericalData.PIE) / (180 * NumericalData.CircleBulletNum)) + NumericalData.PIE / 2), Enemy.transform.position.x + NumericalData.CircleRadius * Mathf.Sin(-((i * 360 * NumericalData.PIE) / (180 * NumericalData.CircleBulletNum)) + NumericalData.PIE / 2), Enemy.transform.position.z), Quaternion.identity, Parent.transform);
            yield return new WaitForSeconds(NumericalData.CircleCreateInterval);
        }
        ParentScript.StartShot = true;
    }
}
