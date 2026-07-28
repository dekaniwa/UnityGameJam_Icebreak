using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    public float MoveSpeed = 5.0f;
    public float JumpPower = 6.0f;

    
    Rigidbody m_rigidBody;
    Animator m_playerAnimator;
    GameObject m_mainCamera;
    bool m_moveFlag, m_jumpFlag, m_airFlag;
    // 接地判定用スクリプト
    public GroundChecker Ground_Checker;
    void Start()
    {
        // 自分にアタッチされているRigidBodyを取得する
        m_rigidBody = GetComponent<Rigidbody>();
        // 自分にアタッチされているAnimatorを取得する
        m_playerAnimator = GetComponent<Animator>();
        // メインカメラのゲームオブジェクトを取得する
        m_mainCamera = Camera.main.gameObject;
    }


    void Update()
    {
        // 移動やジャンプ
        Action();

        // アニメーション
        Animation();
    }


    private void Action()
    {
        // 移動速度を初期化
        Vector3 move = Vector3.zero;

        MoveSpeed = Mathf.Max(2.0f, 5.0f - Inventory.Instance.GetItemCount() * 0.2f);
        // 前後移動
        if (Input.GetKey(KeyCode.W))
        {
            move.z += MoveSpeed;
        }
        if (Input.GetKey(KeyCode.S))
        {
            move.z += -MoveSpeed;
        }
        // 左右移動
        if (Input.GetKey(KeyCode.D))
        {
            move.x += MoveSpeed;
        }
        if (Input.GetKey(KeyCode.A))
        {
            move.x += -MoveSpeed;
        }
        // カメラを考慮した移動
        Vector3 PlayerMove = Vector3.zero;

        Vector3 forward = m_mainCamera.transform.forward;
        Vector3 right = m_mainCamera.transform.right;
        forward.y = 0.0f;
        right.y = 0.0f;
        right *= move.x;
        forward *= move.z;
        // 移動速度に上記で計算したベクトルを加算する
        PlayerMove += right + forward;

        // 移動させる
        transform.position += PlayerMove * Time.deltaTime;
        // 移動フラグの更新
        if (PlayerMove.sqrMagnitude == 0.0f)
        {
            m_moveFlag = false;
        }
        else
        {
            m_moveFlag = true;
        }


        // 回転
        if (PlayerMove.sqrMagnitude > 0.0f)
        {
            transform.rotation = Quaternion.LookRotation(PlayerMove.normalized);
        }
        // ジャンプ
         if (Input.GetKeyDown(KeyCode.Space) && Ground_Checker.GetIsGround())
         {  
            m_rigidBody.AddForce(new Vector3(0.0f, JumpPower, 0.0f),
            ForceMode.VelocityChange);
            m_jumpFlag = true;
         }
    }


    private void Animation()
    {
        // 移動フラグ
        m_playerAnimator.SetBool("MoveFlag", m_moveFlag);

        // ジャンプフラグ
        if (m_jumpFlag && m_airFlag == false &&
            Ground_Checker.GetIsGround() == false)
        {
            m_airFlag = true;
            m_playerAnimator.SetBool("JumpFlag", true);
        }
        if (m_jumpFlag && m_airFlag &&
            Ground_Checker.GetIsGround())
        {
            m_airFlag = false;
            m_jumpFlag = false;
            m_playerAnimator.SetBool("JumpFlag", false);
        }
    }
}
