using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletClass : MonoBehaviour
{
    public float downSpeed;

    public Vector3 StartPosition;

    public float BulletSize;//îºåa
    public float BulletSpeed;
    public float AbsoluteOfAccel;
    public Vector3 BulletVelocity;
    Vector3 accelaration;

    public Transform Player;


    public void SetUp()
    {
        Player = GameObject.FindWithTag("Player").GetComponent<Transform>();
        this.transform.position = StartPosition;
        this.transform.localScale = new Vector3(BulletSize, BulletSize, BulletSize);
    }

    public void homingMove()
    {
        const float nonHomingArea = 2.0f;
        if(Mathf.Abs(this.transform.position.z - Player.transform.position.z) != -1)
        {
                if(Mathf.Abs(this.transform.position.z - Player.transform.position.z) > nonHomingArea)//í«îˆÇ≥ÇπÇ∑Ç¨ÇÈÇ∆ïKÇ∏ìñÇΩÇ¡ÇƒÇµÇ‹Ç§ÇΩÇﬂîÕàÕÇê›ÇØÇÈ
                {
                    AbsoluteOfAccel = 1.5f / (Mathf.Abs(this.transform.position.z - Player.transform.position.z) - 1f);
                }
        }

        accelaration = (Player.transform.position - this.transform.position) * AbsoluteOfAccel;
        BulletVelocity = BulletVelocity.normalized + accelaration * AbsoluteOfAccel * Time.deltaTime;
        this.transform.position += BulletVelocity.normalized * BulletSpeed * Time.deltaTime;
    }

    public void hit()
    {
        if(Mathf.Abs(this.transform.position.y - Player.transform.position.y) <= ObjectSizeData.playerHeight)
        {
            if (Vector2.Distance(new Vector2(this.transform.position.x, this.transform.position.z), new Vector2(Player.transform.position.x, Player.transform.position.z)) <= BulletSize + ObjectSizeData.playerRadius)
            {
                Debug.Log("hit");
                Destroy(this.gameObject);
            }
        }
    }
}
