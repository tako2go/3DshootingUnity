using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UIElements;

public static class PL_Data
{
    //プレイヤー情報
    public static int PlayerSpeed = 8;
    public static float playerRadius = 0.5f;
    public static float playerHeight = 0.5f;

    //プレイヤー攻撃関係
    public static float PL_shotInterVal = 0.1f;//弾を連続発射する速さ
    public static float PL_BulletSpeed = 50f;
    public static float PL_BulletTime = 10.0f;//プレイヤーが発射した弾が滞在している時間
}
