using UnityEngine;

public class Score : MonoBehaviour
{
    public static Score Instance;

    public int score;

    void Awake()
    {
        Instance = this;
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