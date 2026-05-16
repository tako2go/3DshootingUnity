using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    //playerプロパティ
    private int PlayerSpeed = 8;
    private float Gravity = 150;

    //Cameraプロパティ
    public Transform CameraAxis;
    public Transform Camera;
    private Vector3 CameraPosition = new Vector3(0, 0.5f, -5);
    private Quaternion CameraRotation = Quaternion.Euler(0, 0, 0);

    Rigidbody rb;

    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody>();

        this.transform.position = new Vector3(0, 0, 0);
        CameraAxis.transform.position = this.transform.position;
        Camera.transform.position = this.transform.position + CameraPosition;
        Camera.transform.rotation = CameraRotation;
    }

    // Update is called once per frame
    void Update()
    {
        move();
        CamerapPos();

    }


    private void move()
    {
        Vector3 dir = Vector3.zero;
        Vector3 vel = Vector3.zero;
        rb.velocity = new Vector3(0, rb.velocity.y, 0);

        if (Input.GetKey(KeyCode.W))
        {
            dir += Camera.transform.forward;
        }
        if (Input.GetKey(KeyCode.A))
        {
            dir -= Camera.transform.right;
        }
        if (Input.GetKey(KeyCode.S))
        {
            dir -= Camera.transform.forward;
        }
        if (Input.GetKey(KeyCode.D))
        {
            dir += Camera.transform.right;
        }

        if (Input.GetKey(KeyCode.Space))
        {
            dir += this.transform.up;
        }
        if (Input.GetKey(KeyCode.LeftControl))
        {
            dir -= this.transform.up;
        }

        vel = dir.normalized;

        if (dir.x != 0 || dir.z != 0)//xz平面において移動方向を向く
        {
            dir.y = 0;
            transform.rotation = Quaternion.LookRotation(dir);
        }


        if (Mathf.Abs(this.transform.position.x) >= (ObjectSizeData.MoveBoxX / 2) - ObjectSizeData.playerRadius)
        {
            if (this.transform.position.x * dir.x > 0)//中心に対して右、左としたとき、速度方向(x)と現在位置の左右が同じだった場合停止
            {
                vel.x = 0;
            }
        }

        if (Mathf.Abs(this.transform.position.z) >= (ObjectSizeData.MoveBoxZ / 2) - ObjectSizeData.playerRadius)//�ړ��͈͐���
        {
            if (this.transform.position.z * dir.z > 0)
            {
                vel.z = 0;
            }
        }

        if (Mathf.Abs(this.transform.position.y) >= (ObjectSizeData.MoveBoxY / 2) - ObjectSizeData.playerHeight)//�ړ��͈͐���
        {
            if (this.transform.position.y * dir.y > 0)
            {
                vel.z = 0;
            }
        }



        rb.velocity = vel.normalized * PlayerSpeed;

    }

    float AngleX = 0;
    float AngleY = 0;
    private void CamerapPos()
    {
        CameraAxis.transform.position = this.transform.position;

        const int RotateSpeed = 300;

        float mouseInputX = Input.GetAxis("Mouse X");
        float mouseInputY = Input.GetAxis("Mouse Y");

        const int AngleYmin = -47;
        const int AngleYmax = 30;

        AngleX += mouseInputX * RotateSpeed * Time.deltaTime;
        AngleY += mouseInputY * RotateSpeed * Time.deltaTime;

        AngleY = Mathf.Clamp(AngleY, AngleYmin, AngleYmax);

        CameraAxis.transform.eulerAngles = new Vector3(AngleY, AngleX, 0);
    }
}
