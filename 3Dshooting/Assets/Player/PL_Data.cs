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
    public static int PL_Speed = 8;
    //プレイヤーサイズ(円柱とする)
    public static float PL_Radius = 0.25f;//底面半径
    public static float PL_Height = 0.5f;//高さの半分

    //プレイヤー攻撃関係
    public static float PL_shotInterVal = 0.1f;//弾を連続発射する速さ
    public static float PL_BulletSpeed = 50f;
    public static float PL_BulletTime = 10.0f;//プレイヤーが発射した弾が滞在している時間
}
