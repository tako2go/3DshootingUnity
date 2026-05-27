using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class NumericalData
{
    //定数
    public static float PIE = 3.14f;

    //プレイヤー情報
    public static int PlayerSpeed = 8;
    public static float playerRadius = 0.5f;
    public static float playerHeight = 0.5f;
    public static int MoveBoxX = 30;//プレイヤー移動可能範囲
    public static int MoveBoxY = 15;
    public static int MoveBoxZ = 15;

    //カメラ情報
    public static Vector3 CameraStartPosition = new Vector3(0, 1.5f, -5);

    // public static float NomalBulletMax = 2.0f;
    // public static float NomalBulletMin = 0.8f;
    //敵攻撃関係
    public static float EN_BulletSize = 1.0f;
    public static float EN_BulletSpeed = 50f;

    //敵攻撃Circle関係
    public static float CircleCreateInterval = 0.5f;
    public static float CircleShotInterval = 1f;
    public static float CircleRadius = 10.0f;
    public static int CircleBulletNum = 12;


    //プレイヤー攻撃関係
    public static float PL_shotInterVal = 0.1f;
    public static float PL_BulletSpeed = 50f;
}
