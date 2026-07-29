using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    TextMeshProUGUI text;

    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        text.text = Score.Instance.GetScore().ToString();
    }
}