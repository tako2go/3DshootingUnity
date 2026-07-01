using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PL_Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3 vel;
    private GameObject Player;//プレイヤーの位置情報、カメラの向きの反対が入っている。
    float timer = 0;
    void Start()
    {
        Player = GameObject.Find("Axis");
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position += vel * PL_Data.PL_BulletSpeed * Time.deltaTime;
        timer += Time.deltaTime;
        if (timer > PL_Data.PL_Bullet_DeleteTime)//
        {
            Destroy(this.gameObject);
        }
    }


}
