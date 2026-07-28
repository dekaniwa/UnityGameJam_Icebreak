using TMPro;
using UnityEngine;

public class FruitText : MonoBehaviour
{
    private TextMeshProUGUI text;

    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        text.text = "Fruit : " + Inventory.Instance.GetItemCount();
    }
}