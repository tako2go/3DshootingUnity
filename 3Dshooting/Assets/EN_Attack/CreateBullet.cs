using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBullet : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject NomalBullet;
    public GameObject HomingBullet;
    float timer = 0;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 3.0f)
        {
            Instantiate(NomalBullet);
            timer = 0;
        }
    }
}
