using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class CameraAxis : MonoBehaviour
{
    public Transform Player;
    void Update()
    {
        int RotateSpeed = 300;
       
        this.transform.position = Player.position;

        float mouseInputY = Input.GetAxis("Mouse Y");
        this.transform.Rotate(Vector3.right, mouseInputY * RotateSpeed * Time.deltaTime);
    }
}
