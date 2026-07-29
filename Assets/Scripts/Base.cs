using UnityEngine;

public class Base : MonoBehaviour
{
    public GameObject applePrefab;
    public GameObject lemonPrefab;
    public GameObject carrotPrefab;
    public GameObject bananaPrefab;
    public GameObject orangePrefab;
    private bool canDelivery = false;
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;

        canDelivery = true;
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canDelivery = false;
        }
    }
    private void Update()
    {
        if (canDelivery && Input.GetKeyDown(KeyCode.E))
        {
            Delivery();
        }
    }
    void Delivery()
    {
        Debug.Log("納品開始！");
        SEManager.Instance.PlayDelivery();
        Score.Instance.AddScore(Inventory.Instance.apple * 100);
        Score.Instance.AddScore(Inventory.Instance.lemon * 150);
        Score.Instance.AddScore(Inventory.Instance.carrot * 80);
        Score.Instance.AddScore(Inventory.Instance.banana * 120);
        Score.Instance.AddScore(Inventory.Instance.orange * 200);

        SpawnItems(applePrefab, Inventory.Instance.apple);
        SpawnItems(lemonPrefab, Inventory.Instance.lemon);
        SpawnItems(carrotPrefab, Inventory.Instance.carrot);
        SpawnItems(bananaPrefab, Inventory.Instance.banana);
        SpawnItems(orangePrefab, Inventory.Instance.orange);
        Score.Instance.appleCount += Inventory.Instance.apple;
        Score.Instance.lemonCount += Inventory.Instance.lemon;
        Score.Instance.carrotCount += Inventory.Instance.carrot;
        Score.Instance.bananaCount += Inventory.Instance.banana;
        Score.Instance.orangeCount += Inventory.Instance.orange;
        Inventory.Instance.apple = 0;
        Inventory.Instance.lemon = 0;
        Inventory.Instance.carrot = 0;
        Inventory.Instance.banana = 0;
        Inventory.Instance.orange = 0;
    }
    void SpawnItems(GameObject prefab, int count)
    {
        for (int i = 0; i < count; i++)
        {
            Vector3 pos = transform.position + new Vector3(
                Random.Range(-1f, 1f),
                0.5f,
                Random.Range(-1f, 1f)
            );

            GameObject item = Instantiate(prefab, pos, Quaternion.identity);

            Rigidbody rb = item.GetComponent<Rigidbody>();
            Debug.Log("生成した：" + item.name);
            if (rb != null)
            {
                Vector3 force = new Vector3(
                    Random.Range(-3f, 3f),
                    5f,
                    Random.Range(-3f, 3f)
                );

                rb.AddForce(force, ForceMode.Impulse);
            }
            
        }
        
    }
}