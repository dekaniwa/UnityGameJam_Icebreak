using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class TimerManager : MonoBehaviour
{
    public static TimerManager Instance { get; private set; }

    [SerializeField] private float timeLimit = 180.0f;
    [SerializeField] private TextMeshProUGUI timerText;

    private float currentTime;
    private bool isTimerRunning = false;

    public event Action OnTimeUp;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        currentTime = timeLimit;
        isTimerRunning = false;
        UpdateTimerDisplay();
    }

    void Update()
    {
        if (!isTimerRunning) return;

        currentTime -= Time.deltaTime;

        if (currentTime <= 0f)
        {
            currentTime = 0f;
            isTimerRunning = false;

            Debug.Log("制限時間終了");

            OnTimeUp?.Invoke();

            SceneManager.LoadScene("Result");
        }

        UpdateTimerDisplay();
    }

    void UpdateTimerDisplay()
    {
        if (timerText == null) return;

        int minutes = Mathf.FloorToInt(currentTime / 60f);
        int seconds = Mathf.FloorToInt(currentTime % 60f);

        timerText.text = $"{minutes}:{seconds:00}";
    }

    public void StopTimer()
    {
        isTimerRunning = false;
    }

    public void ResumeTimer()
    {
        isTimerRunning = true;
    }

    public float GetRemainingTime()
    {
        return currentTime;
    }
}