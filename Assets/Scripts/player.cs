using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float MoveSpeed = 8.0f;

    Rigidbody m_rigidBody;
    Animator m_playerAnimator;
    GameObject m_mainCamera;
    bool m_moveFlag;

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
        // 移動
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
            move.z -= MoveSpeed;
        }

        // 左右移動
        if (Input.GetKey(KeyCode.D))
        {
            move.x += MoveSpeed;
        }
        if (Input.GetKey(KeyCode.A))
        {
            move.x -= MoveSpeed;
        }

        // カメラを考慮した移動
        Vector3 playerMove = Vector3.zero;

        Vector3 forward = m_mainCamera.transform.forward;
        Vector3 right = m_mainCamera.transform.right;
        forward.y = 0.0f;
        right.y = 0.0f;

        right *= move.x;
        forward *= move.z;

        playerMove += right + forward;

        // 移動
        transform.position += playerMove * Time.deltaTime;

        // 移動フラグ
        m_moveFlag = playerMove.sqrMagnitude > 0.0f;

        // 回転
        if (playerMove.sqrMagnitude > 0.0f)
        {
            transform.rotation = Quaternion.LookRotation(playerMove.normalized);
        }
    }

    private void Animation()
    {
        // 移動アニメーション
        m_playerAnimator.SetBool("MoveFlag", m_moveFlag);
    }
}