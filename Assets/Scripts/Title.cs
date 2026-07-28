using UnityEngine;

public class TitleCameraMove : MonoBehaviour
{
    private Transform mainCamera;

    [Header("カメラ位置")]
    public Transform titleCameraPos;
    public Transform gameCameraPos;

    [Header("移動設定")]
    public float transitionDuration = 2.0f; // 移動にかける秒数

    [Header("プレイヤー")]
    public MonoBehaviour playerController;

    [Header("競合するカメラスクリプト")]
    public GameCamera gameCameraScript; // GameCamera.csをここにドラッグ

    private bool moveCamera = false;
    private bool gameStarted = false;
    private float elapsedTime = 0f;

    void Start()
    {
        mainCamera = Camera.main.transform;

        // タイトル演出中はGameCameraを無効化しておく(位置の取り合いを防ぐ)
        if (gameCameraScript != null)
            gameCameraScript.enabled = false;

        mainCamera.position = titleCameraPos.position;
        mainCamera.rotation = titleCameraPos.rotation;

        if (playerController != null)
            playerController.enabled = false;
    }

    void Update()
    {
        if (!gameStarted)
        {
            if (Input.GetKeyDown(KeyCode.JoystickButton0) || Input.GetKeyDown(KeyCode.J))
            {
                gameStarted = true;
                moveCamera = true;
                elapsedTime = 0f;
            }
            return;
        }

        if (!moveCamera) return;

        elapsedTime += Time.deltaTime;
        float t = Mathf.Clamp01(elapsedTime / transitionDuration);

        mainCamera.position = Vector3.Lerp(titleCameraPos.position, gameCameraPos.position, t);
        mainCamera.rotation = Quaternion.Slerp(titleCameraPos.rotation, gameCameraPos.rotation, t);

        if (t >= 1f)
        {
            moveCamera = false;

            // 移動が終わったのでGameCameraを再度有効化
            if (gameCameraScript != null)
                gameCameraScript.enabled = true;

            if (playerController != null)
                playerController.enabled = true;
            TimerManager.Instance.ResumeTimer();
        }
    }
}