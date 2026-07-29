using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResultManager : MonoBehaviour
{
    public GameObject applePrefab;
    public GameObject lemonPrefab;
    public GameObject carrotPrefab;
    public GameObject bananaPrefab;
    public GameObject orangePrefab;

    public Transform spawnPoint;

    public float spawnInterval = 0.2f;

    void Start()
    {
        StartCoroutine(SpawnForever());
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.JoystickButton0) ||
            Input.GetKeyDown(KeyCode.J))
        {
            Score.Instance.ResetData();

            SceneManager.LoadScene("Title");
        }
    }

    IEnumerator SpawnForever()
    {
        while (true)
        {
            GameObject prefab = GetRandomPrefab();

            Vector3 pos = spawnPoint.position + new Vector3(
                Random.Range(-0.3f, 0.3f),
                0f,
                Random.Range(-0.3f, 0.3f)
            );

            Instantiate(prefab, pos, Quaternion.identity);

            yield return new WaitForSeconds(spawnInterval);
        }
    }

    GameObject GetRandomPrefab()
    {
        int random = Random.Range(0, 5);

        switch (random)
        {
            case 0:
                return applePrefab;
            case 1:
                return lemonPrefab;
            case 2:
                return carrotPrefab;
            case 3:
                return bananaPrefab;
            default:
                return orangePrefab;
        }
    }
}