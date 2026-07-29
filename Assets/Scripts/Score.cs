using UnityEngine;

public class Score : MonoBehaviour
{
    public static Score Instance;

    public int score;

    // 納品した果物の数
    public int appleCount;
    public int lemonCount;
    public int carrotCount;
    public int bananaCount;
    public int orangeCount;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddScore(int point)
    {
        score += point;
    }

    public int GetScore()
    {
        return score;
    }
}