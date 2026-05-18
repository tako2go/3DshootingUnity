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
        for (int i = 0; i < 12; i++)
        {
            Instantiate(CircleBullet, new Vector3(Enemy.transform.position.x + NumericalData.CircleRadius * Mathf.Cos(-(i * NumericalData.PIE * 2 / 12) + NumericalData.PIE / 2), Enemy.transform.position.x + NumericalData.CircleRadius * Mathf.Sin(-(i * NumericalData.PIE * 2 / 12) + NumericalData.PIE / 2), Enemy.transform.position.z), Quaternion.identity, Parent.transform);
            yield return new WaitForSeconds(NumericalData.CreateInterval);
        }
    }
}
