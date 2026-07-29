using UnityEngine;

public class DebugFruitSpawner : MonoBehaviour
{
    public GameObject applePrefab;
    public GameObject lemonPrefab;
    public GameObject carrotPrefab;
    public GameObject bananaPrefab;
    public GameObject orangePrefab;

    public Transform spawnPoint;

    private bool canSpawn = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canSpawn = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canSpawn = false;
        }
    }

    void Update()
    {
        if (!canSpawn)
            return;

        // T + Q + N を同時押し
        if (Input.GetKey(KeyCode.T) &&
            Input.GetKey(KeyCode.Q) &&
            Input.GetKey(KeyCode.N))
        {
            SpawnFruit(applePrefab);
            SpawnFruit(lemonPrefab);
            SpawnFruit(carrotPrefab);
            SpawnFruit(bananaPrefab);
            SpawnFruit(orangePrefab);
        }
    }

    void SpawnFruit(GameObject prefab)
    {
        Vector3 pos = spawnPoint.position + new Vector3(
            Random.Range(-1f, 1f),
            0.5f,
            Random.Range(-1f, 1f)
        );

        GameObject fruit = Instantiate(prefab, pos, Quaternion.identity);

        Rigidbody rb = fruit.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.AddForce(new Vector3(
                Random.Range(-2f, 2f),
                5f,
                Random.Range(-2f, 2f)
            ), ForceMode.Impulse);
        }
    }
}