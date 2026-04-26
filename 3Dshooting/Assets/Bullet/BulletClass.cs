using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletClass : MonoBehaviour
{

    public Vector3 StartPosition;

    public float BulletSize;//îºåa
    public float BulletSpeed;
    float AbsoluteOfAccel = 3.0f;
    Vector3 BulletVelocity;
    Vector3 accelaration;

    Transform Player;


    public void SetUp()
    {
        Player = GameObject.FindWithTag("Player").GetComponent<Transform>();
        this.transform.position = StartPosition;
        this.transform.localScale = new Vector3(BulletSize, BulletSize, BulletSize);
    }

    public void move()
    {
        //accelaration = Player.transform.position - this.transform.position;
        //rb.velocity += accelaration.normalized * AbsoluteOfAccel * Time.deltaTime;
        this.transform.position += new Vector3(0, 0, -BulletSpeed) * Time.deltaTime;
        Debug.Log("à⁄ìÆíÜ");
    }
    
    public void disApp()//è¡Ç∑
    {
        if(this.transform.position.y <= 0 || this.transform.position.z <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
