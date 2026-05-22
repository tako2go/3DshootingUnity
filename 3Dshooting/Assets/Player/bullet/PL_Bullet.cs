using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PL_Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3 vel;
    private GameObject Player;//プレイヤーの位置情報、カメラの向きの反対が入っている。
    void Start()
    {
        Player = GameObject.Find("Axis");
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position += vel * NumericalData.PL_BulletSpeed * Time.deltaTime;
        float dx = Player.transform.position.x - this.transform.position.x;
        float dy = Player.transform.position.y - this.transform.position.y;
        float dz = Player.transform.position.z - this.transform.position.z;
        if (dx * dx + dy * dy + dz * dz > 900)//距離差が30より大きくなったら
        {
            Destroy(this.gameObject);
        }
    }
}
