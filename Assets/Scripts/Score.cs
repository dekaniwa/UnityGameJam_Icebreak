using UnityEngine;

public class Score : MonoBehaviour
{
    public static Score Instance;

    public int score;

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

    public void ResetData()
    {
        score = 0;

        appleCount = 0;
        lemonCount = 0;
        carrotCount = 0;
        bananaCount = 0;
        orangeCount = 0;
    }
}