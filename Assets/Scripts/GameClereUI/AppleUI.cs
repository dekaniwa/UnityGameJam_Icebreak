using TMPro;
using UnityEngine;

public class AppleText : MonoBehaviour
{
    TextMeshProUGUI text;

    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        text.text = Score.Instance.appleCount.ToString();
    }
}