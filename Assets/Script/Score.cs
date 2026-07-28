using UnityEngine;
using UnityEngine.SceneManagement;

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
}
