using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EN_Data : MonoBehaviour
{
    // public static float NomalBulletMax = 2.0f;
    // public static float NomalBulletMin = 0.8f;

    //敵情報
    public static Vector3 BasePos = new Vector3(0, 0, 20);
    public static Quaternion StartRot = Quaternion.Euler(0, 180, 0);

    //敵攻撃関係
    public static float EN_BulletSize = 0.5f;//弾の半径
    public static float EN_BulletSpeed = 15f;
    public static float destinatonRadius = 1.0f;//目的地に到達したとみなす半径
    //敵攻撃Circle関係
    public static float CircleCreateInterval = 0.5f;
    public static float CircleShotInterval = 1f;
    public static float CircleRadius = 10.0f;
    public static int CircleBulletNum = 12;

    //敵攻撃CircleWave関係
    public static float CircleWaveCreateInterval = 0.5f;
    public static float CircleWaveRadius = 5.0f;
}
