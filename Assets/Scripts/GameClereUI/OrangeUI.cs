using TMPro;
using UnityEngine;

public class OrangeText : MonoBehaviour
{
    TextMeshProUGUI text;

    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        text.text = Score.Instance.orangeCount.ToString();
    }
}