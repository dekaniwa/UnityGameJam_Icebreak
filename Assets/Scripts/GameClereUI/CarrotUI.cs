using TMPro;
using UnityEngine;

public class CarrotText : MonoBehaviour
{
    TextMeshProUGUI text;

    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        text.text = Score.Instance.carrotCount.ToString();
    }
}