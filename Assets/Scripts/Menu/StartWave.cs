using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartWave : MonoBehaviour
{
    [SerializeField] GameObject enemy;
    [SerializeField] int enemyNumber = 0;
    [SerializeField] float spawnDealy = 0.5f;
    GameObject spawner;
    Button startWave;
    // Start is called before the first frame update
    void Start()
    {
        spawner = GameObject.Find("EnemySpawner");
        startWave = GetComponent<Button>();
        startWave.onClick.AddListener(StartWaves);
    }

    void StartWaves()
    {
        Debug.Log("Start is clicked");
        if(!EnemySpawner.waveIsActive)
        {
            Debug.Log("Start Wave");
            StartCoroutine(Spawn());
        }
    }

    IEnumerator Spawn()
    {
        for (int i = 0; i < enemyNumber; i++)
        {
            Instantiate(enemy, spawner.transform.position, Quaternion.identity);
            yield return new WaitForSeconds(spawnDealy);
        }
    }
}
