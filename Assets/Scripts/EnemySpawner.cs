using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject enemy;
    [SerializeField] int enemyNumber = 0;
    [SerializeField] float spawnDealy = 0.5f;

    public static bool waveIsActive = false;

    void Start()
    {

        if(!waveIsActive)
        {
            waveIsActive = true;
            StartWave();
        }
    }

    public void StartWave()
    {
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        for (int i = 0; i < enemyNumber; i++)
        {
            //Vector2 pos = spawnPos.position + new Vector3(0, Random.Range(-range.y, range.y));
            yield return new WaitForSeconds(spawnDealy);
            Instantiate(enemy, gameObject.transform.position, Quaternion.identity);
        }
        waveIsActive = false;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
