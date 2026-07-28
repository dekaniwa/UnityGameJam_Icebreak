using UnityEngine;

public class TitleCameraMove : MonoBehaviour
{
    private Transform mainCamera; // 呼び出したMain Cameraのtransformを保持

    [Header("カメラ位置")]
    public Transform titleCameraPos;   // マップ全体を見せる位置
    public Transform gameCameraPos;    // ゲーム開始時のカメラ位置

    [Header("移動設定")]
    public float moveSpeed = 50.0f;     // 移動速度
    public float rotateSpeed = 60f;    // 回転速度(度/秒)

    [Header("プレイヤー")]
    public MonoBehaviour playerController; // プレイヤー操作スクリプト(あれば)

    private bool moveCamera = false;   // 移動中かどうかのフラグ
    private bool gameStarted = false;  // すでにスタート済みかどうか

    void Start()
    {
        // シーン内のMainCameraタグが付いたカメラを探して取得
        mainCamera = Camera.main.transform;

        // ゲーム開始時、カメラをタイトル位置に固定
        mainCamera.position = titleCameraPos.position;
        mainCamera.rotation = titleCameraPos.rotation;

        // プレイヤー操作はまだ無効にしておく
        if (playerController != null)
            playerController.enabled = false;
    }

    void Update()
    {
        Debug.Log("Update実行中");

        // まだスタートしていない間、Aボタンの入力をチェック
        if (!gameStarted)
        {
            // コントローラーのAボタン(joystick button 0) または キーボードのSpaceキー
            if (Input.GetKeyDown(KeyCode.JoystickButton0) || Input.GetKeyDown(KeyCode.J))
            {
                gameStarted = true;
                moveCamera = true;
            }
            return;
        }

        // ここから下はカメラ移動処理
        if (!moveCamera) return;

        // 現在位置からgameCameraPosへ徐々に近づける
        mainCamera.position = Vector3.MoveTowards(
            mainCamera.position,
            gameCameraPos.position,
            moveSpeed * Time.deltaTime
        );

        // 向きも同時に近づける
        mainCamera.rotation = Quaternion.RotateTowards(
            mainCamera.rotation,
            gameCameraPos.rotation,
            rotateSpeed * Time.deltaTime
        );

        // 十分近づいたら移動終了とみなす
        if (Vector3.Distance(mainCamera.position, gameCameraPos.position) < 0.05f)
        {
            mainCamera.position = gameCameraPos.position;
            mainCamera.rotation = gameCameraPos.rotation;
            moveCamera = false;

            // 到着したのでプレイヤー操作を有効化
            if (playerController != null)
                playerController.enabled = true;
        }
    }
}