using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    //初期設定値
    private int PlayerminY = 1;

    //プレイヤーパラメータ
    private int PlayerSpeed = 4000;
    private int PlayerJumpPower = 30;
    private float Gravity = 150;

    //カメラ設定
    public Transform CameraAxis;
    public Transform Camera;
    private Vector3 CameraPosition = new Vector3(0, 0.5f, -5);
    private Quaternion CameraRotation = Quaternion.Euler(0, 0, 0);


    void Start()
    {
        this.transform.position = new Vector3(0, PlayerminY, 0);
        Camera.transform.position = this.transform.position + CameraPosition;
        Camera.transform.rotation = CameraRotation;
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
        GetComponent<Rigidbody>().velocity = new Vector3(0, GetComponent<Rigidbody>().velocity.y, 0);

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




        if ((this.transform.position.z) <= 0 + ObjectSizeData.Player)//移動範囲制限
        {
            if (dir.z < 0)
            {
                dir.z = 0;
            }
        }

        if (Mathf.Abs(this.transform.position.x) >= ObjectSizeData.floor - ObjectSizeData.Player)
        {
            if (this.transform.position.x * dir.x > 0)//現在の座標(x)と移動方向(x)が同符号だったら
            {
                dir.x = 0;
            }
        }

        vel = dir;
        GetComponent<Rigidbody>().velocity = new Vector3((vel * PlayerSpeed * Time.deltaTime).x, GetComponent<Rigidbody>().velocity.y, (vel * PlayerSpeed * Time.deltaTime).z);//キーによる合成ベクトルの方向へ速さPlayerSpeed

    }

    float AngleX = 0;
    float AngleY = 0;
    private void CamerapPos()
    {
        CameraAxis.transform.position = this.transform.position;

        const int RotateSpeed = 300;

        float mouseInputX = Input.GetAxis("Mouse X");
        float mouseInputY = Input.GetAxis("Mouse Y");

        const int AngleYmin = -17;
        const int AngleYmax = 30;

        AngleX += mouseInputX * RotateSpeed * Time.deltaTime;
        AngleY += mouseInputY * RotateSpeed * Time.deltaTime;

        AngleY = Mathf.Clamp(AngleY, AngleYmin, AngleYmax);

        CameraAxis.transform.eulerAngles = new Vector3(AngleY, AngleX, 0);
    }

    private void Jump()
    {
        if (this.transform.position.y <= PlayerminY)//地上
        {
            this.GetComponent<Rigidbody>().velocity = new Vector3(this.GetComponent<Rigidbody>().velocity.x, 0, this.GetComponent<Rigidbody>().velocity.z);
            if (Input.GetKey(KeyCode.Space))
            {
                this.GetComponent<Rigidbody>().velocity = new Vector3(this.GetComponent<Rigidbody>().velocity.x, PlayerJumpPower, this.GetComponent<Rigidbody>().velocity.z);
            }
        }
        else//空中
        {
            this.GetComponent<Rigidbody>().velocity -= new Vector3(0, Gravity, 0) * Time.deltaTime;
        }
    }
}
