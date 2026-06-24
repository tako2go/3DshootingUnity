using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{

    //Cameraプロパティ
    [SerializeField] Transform CameraAxisTf;
    [SerializeField] Transform CameraTf;



    Rigidbody rb;

    //攻撃関係
    private float shotTimer = PL_Data.PL_shotInterVal;//スタート時点で発射できるようにするため
    public GameObject PlayerBullet;

    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody>();

        this.transform.position = new Vector3(0, 0, 0);
        CameraAxisTf.transform.position = this.transform.position;
        CameraTf.transform.position = this.transform.position + PL_Data.CameraStartPosition;
        CameraTf.transform.rotation = PL_Data.CameraRotation;
    }

    // Update is called once per frame
    void Update()
    {
        move();
        CamerapPos();
        if (Input.GetMouseButton(1))
        {
            shot();
        }
    }


    private void move()
    {
        Vector3 dir = Vector3.zero;
        Vector3 vel = Vector3.zero;
        rb.velocity = new Vector3(0, rb.velocity.y, 0);

        if (Input.GetKey(KeyCode.W))
        {
            dir += CameraTf.transform.forward;
        }
        if (Input.GetKey(KeyCode.A))
        {
            dir -= CameraTf.transform.right;
        }
        if (Input.GetKey(KeyCode.S))
        {
            dir -= CameraTf.transform.forward;
        }
        if (Input.GetKey(KeyCode.D))
        {
            dir += CameraTf.transform.right;
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

        if (!Input.GetMouseButton(1))
        {
            if (dir.x != 0 || dir.z != 0)//xz平面において移動方向を向く
            {
                dir.y = 0;
                transform.rotation = Quaternion.LookRotation(dir);
            }
        }
        else
        {
            transform.rotation = Quaternion.LookRotation(new Vector3(CameraTf.transform.forward.x, 0, CameraTf.transform.forward.z));
        }


        if (Mathf.Abs(this.transform.position.x) >= (NumericalData.MoveBoxX / 2) - PL_Data.PL_Radius)
        {
            if (this.transform.position.x * dir.x > 0)//中心に対して右、左としたとき、速度方向(x)と現在位置の左右が同じだった場合停止
            {
                vel.x = 0;
            }
        }

        if (Mathf.Abs(this.transform.position.z) >= (NumericalData.MoveBoxZ / 2) - PL_Data.PL_Radius)//�ړ��͈͐���
        {
            if (this.transform.position.z * dir.z > 0)
            {
                vel.z = 0;
            }
        }

        if (Mathf.Abs(this.transform.position.y) >= (NumericalData.MoveBoxY / 2) - PL_Data.PL_Height)//�ړ��͈͐���
        {
            if (this.transform.position.y * dir.y > 0)
            {
                vel.y = 0;
            }
        }



        rb.velocity = vel.normalized * PL_Data.PL_Speed;

    }

    float AngleX = 0;
    float AngleY = 0;

    public int RotateSpeed = 150;
    private void CamerapPos()
    {
        CameraAxisTf.transform.position = this.transform.position;


        float mouseInputX = Input.GetAxis("Mouse X");
        float mouseInputY = Input.GetAxis("Mouse Y");

        const int AngleYmin = -47;
        const int AngleYmax = 30;

        AngleX += mouseInputX * RotateSpeed * Time.deltaTime;
        AngleY += mouseInputY * RotateSpeed * Time.deltaTime;

        AngleY = Mathf.Clamp(AngleY, AngleYmin, AngleYmax);

        CameraAxisTf.transform.eulerAngles = new Vector3(AngleY, AngleX, 0);
    }

    private void shot()
    {
        GameObject Bullet;
        Ray ray = new Ray(CameraTf.transform.position, CameraTf.transform.forward);
        RaycastHit hit;

        shotTimer += Time.deltaTime;
        if (Input.GetMouseButton(0))
        {
            if (shotTimer >= PL_Data.PL_shotInterVal)
            {
                Vector3 BulletPos = new Vector3(transform.position.x, transform.position.y + PL_Data.PL_Height / 2, this.transform.position.z);
                Bullet = Instantiate(PlayerBullet, BulletPos, Quaternion.identity);
                if (Physics.Raycast(ray, out hit, 100f))//現在は適当な値100にしている　十分すぎるため余裕があったら修正
                {
                    Bullet.GetComponent<PL_Bullet>().vel = (hit.collider.gameObject.transform.position - BulletPos).normalized;
                }
                else
                {
                    Bullet.GetComponent<PL_Bullet>().vel = CameraTf.forward;//基本的にカメラに対してプレイヤーは下にいるため、微調整の値を足す
                }

                shotTimer = 0;
            }
        }
    }
}
