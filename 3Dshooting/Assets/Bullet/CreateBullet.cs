using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBullet : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Nomalbullet;
    float timer  = 0;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 3.0f)
        {
            Instantiate(Nomalbullet);
            timer = 0;
        }
    }
}
