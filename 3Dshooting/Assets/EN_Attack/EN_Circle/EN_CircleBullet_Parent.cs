using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EN_CircleBullet_Parent : MonoBehaviour
{
    public bool StartShot = false;
    public GameObject[] Bullets = new GameObject[EN_Data.CircleBulletNum];
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (StartShot)
        {
            StartCoroutine(ShotCircle());
            StartShot = false;
        }
    }

    IEnumerator ShotCircle()
    {
        EN_CircleBullet childBullet;
        for (int i = 0; i < EN_Data.CircleBulletNum; i++)
        {
            childBullet = Bullets[i].GetComponent<EN_CircleBullet>();
            childBullet.shot = true;
            childBullet.BulletVelocity = (childBullet.Player.transform.position - Bullets[i].transform.position).normalized * EN_Data.EN_BulletSpeed * Time.deltaTime;

            yield return new WaitForSeconds(EN_Data.CircleShotInterval);
        }
        Destroy(this.gameObject);
    }
}
