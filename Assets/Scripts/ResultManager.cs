

using System.Collections;
using UnityEngine;

public class ResultManager : MonoBehaviour
{
    public GameObject applePrefab;
    public GameObject lemonPrefab;
    public GameObject carrotPrefab;
    public GameObject bananaPrefab;
    public GameObject orangePrefab;

    public Transform spawnPoint;

    void Start()
    {
        StartCoroutine(SpawnForever());
    }

    IEnumerator SpawnForever()
    {
        while (true)
        {
            // ランダムにPrefabを選ぶ
            int random = Random.Range(0, 5);

            GameObject prefab = null;

            switch (random)
            {
                case 0:
                    prefab = applePrefab;
                    break;
                case 1:
                    prefab = lemonPrefab;
                    break;
                case 2:
                    prefab = carrotPrefab;
                    break;
                case 3:
                    prefab = bananaPrefab;
                    break;
                case 4:
                    prefab = orangePrefab;
                    break;
            }

            // 少しランダムな位置に出す
            Vector3 pos = spawnPoint.position + new Vector3(
                Random.Range(-0.3f, 0.3f),
                0f,
                Random.Range(-0.3f, 0.3f)
            );

            Instantiate(prefab, pos, Quaternion.identity);

            yield return new WaitForSeconds(0.2f);
        }
    }
}