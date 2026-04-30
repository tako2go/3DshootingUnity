using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    //初期設定値
    private int PlayerminY = 1;

    //プレイヤーパラメータ
    private int PlayerSpeed = 8;
    private int PlayerJumpPower = 30;
    private float Gravity = 150;

    //カメラ設定
    public Transform CameraAxis;
    public Transform Camera;
    private Vector3 CameraPosition = new Vector3(0, 0.5f, -5);
    private Quaternion CameraRotation = Quaternion.Euler(0, 0, 0);
    private float CameraDistance;//カメラとプレイヤーの距離

    Rigidbody rb;

    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody>();

        this.transform.position = new Vector3(0, PlayerminY, 5);
        CameraAxis.transform.position = this.transform.position;
        Camera.transform.position = this.transform.position + CameraPosition;
        Camera.transform.rotation = CameraRotation;
        CameraDistance = Vector3.Distance(this.transform.position, Camera.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        move();
        CamerapPos();

    }

    private void FixedUpdate()
    {
        Jump();
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

        dir = dir.normalized;

        if (dir.x != 0 || dir.z != 0)
        {
            dir.y = 0;
            transform.rotation = Quaternion.LookRotation(dir);
        }




        if ((this.transform.position.z) <= 0 + ObjectSizeData.playerRadius)//移動範囲制限
        {
            if (dir.z < 0)
            {
                dir.z = 0;
            }
        }

        if (Mathf.Abs(this.transform.position.x) >= ObjectSizeData.floorX - ObjectSizeData.playerRadius)
        {
            if (this.transform.position.x * dir.x > 0)//現在の座標(x)と移動方向(x)が同符号だったら
            {
                dir.x = 0;
            }
        }

        vel = dir;
        rb.velocity = new Vector3((vel * PlayerSpeed).x, rb.velocity.y, (vel * PlayerSpeed).z);//キーによる合成ベクトルの方向へ速さPlayerSpeed

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

        int CameraLimitSpeed = 30;//カメラ位置制御時の速度
        if (Mathf.Abs(Camera.transform.position.x) > ObjectSizeData.floorX || Camera.transform.position.z < 0 || Camera.transform.position.y < 0) //x方向
        {
            Camera.transform.position += Camera.transform.forward * CameraLimitSpeed * Time.deltaTime;
        }
        else if (Vector3.Distance(this.transform.position, Camera.transform.position) < CameraDistance && (Mathf.Abs(Camera.transform.position.x) < ObjectSizeData.floorX  || Camera.transform.position.z > 0 || Camera.transform.position.y > 0))
        {
            if (mouseInputX != 0 || mouseInputY != 0 || rb.velocity != Vector3.zero)
            {
                Camera.transform.position -= Camera.transform.forward * CameraLimitSpeed * Time.deltaTime;
            //Debug.Log(rb.velocity.x);
        }
    }



    }

    private void Jump()
    {


        if (this.transform.position.y <= PlayerminY)//地上
        {
            rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
            if (Input.GetKey(KeyCode.Space))
            {
                rb.velocity = new Vector3(rb.velocity.x, PlayerJumpPower, rb.velocity.z);
            }
        }
        else//空中
        {
            rb.velocity -= new Vector3(0, Gravity, 0) * Time.deltaTime;
        }
    }
}
