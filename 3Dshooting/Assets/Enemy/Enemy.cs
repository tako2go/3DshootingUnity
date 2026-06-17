using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.transform.position = EN_Data.StartPos;
        this.transform.rotation = EN_Data.StartRot;
    }

    // Update is called once per frame
    void Update()
    {

    }


    void move()
    {

    }
}
