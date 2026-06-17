using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3 destinaton = EN_Data.BasePos;
    Vector3 Velocity = Vector3.zero;
    bool MoveFlag = false;
    float timer = 0;
    void Start()
    {
        this.transform.position = EN_Data.BasePos;
        this.transform.rotation = EN_Data.StartRot;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 20)
        {
            destinaton = new Vector3(10, -10, EN_Data.BasePos.z);
        }
        else if (timer >= 15)
        {
            destinaton = new Vector3(-10, -10, EN_Data.BasePos.z);
        }
        else if (timer >= 10)
        {
            destinaton = new Vector3(-10, 10, EN_Data.BasePos.z);

        }
        else if (timer >= 5)
        {
            destinaton = new Vector3(10, 10, EN_Data.BasePos.z);
        }
        else
        {
            destinaton = EN_Data.BasePos;
        }

        if (timer >= 25)
        {
            timer = 0;
        }
        move();
    }


    void move()
    {
        MoveFlag = ((destinaton - this.transform.position).sqrMagnitude > EN_Data.destinatonRadius * EN_Data.destinatonRadius);

        if (MoveFlag)
        {
            Velocity = (destinaton - this.transform.position).normalized * EN_Data.EN_Speed * Time.deltaTime;
            this.transform.position += Velocity;
        }
    }
}
