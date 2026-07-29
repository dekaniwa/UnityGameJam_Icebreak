using TMPro;
using UnityEngine;

public class BananaText : MonoBehaviour
{
    TextMeshProUGUI text;

    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        text.text = Score.Instance.bananaCount.ToString();
    }
}