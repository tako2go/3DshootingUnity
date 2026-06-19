using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EN_Tutorial : MonoBehaviour
{
    // Start is called before the first frame update

    bool MoveFlag = false;
    float timer = 0;
    EN_Action_Tutorial Action;
    public GameObject Red;
    void Start()
    {
        this.transform.position = EN_Data.BasePos;
        this.transform.rotation = EN_Data.StartRot;
        Action = this.GetComponent<EN_Action_Tutorial>();
        Action.Move_Shot(new Vector3(10, 10, 20), 5, () => { Action.CreateNomalHoming(Red); }, 1);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
