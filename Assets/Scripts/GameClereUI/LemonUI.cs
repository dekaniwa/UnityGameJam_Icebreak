using TMPro;
using UnityEngine;

public class LemonText : MonoBehaviour
{
    TextMeshProUGUI text;

    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        text.text = Score.Instance.lemonCount.ToString();
    }
}