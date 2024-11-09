using System.Collections;
using System.Collections.Generic;
//using System.Management.Instrumentation;
using UnityEngine;

public class TowerAtack : MonoBehaviour
{
    [Header("Скорость атаки")]
    [Header("Параметры башни скрипт")]

    public float atackSpeed = 0.5f;
    [Header("Обнаруженные противники")]
    public List<GameObject> enemiesInRange = new List<GameObject>();
    [Header("Проджектайл")]
    [SerializeField] GameObject projectileObject;
    public static GameObject firstEnemy;
    bool isAtacking = false;

    public float qSpeed = 2f;
    [SerializeField] Transform towerGun;
    [SerializeField] Transform projetileInstantiatePos;
    private void Start()
    {

    }
    private float timeCount = 0.0f;
    private void Update()
    {
        Debug.Log(enemiesInRange.Count);
        if (enemiesInRange.Count > 0)
        {
            if (enemiesInRange[0] != null)
            {
                var dir = enemiesInRange[0].transform.position - transform.position;
                float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90;
                towerGun.transform.rotation = Quaternion.Slerp(towerGun.transform.rotation, Quaternion.AngleAxis(angle, Vector3.forward), qSpeed * Time.deltaTime);
                if (!isAtacking)
                {
                    Instantiate(projectileObject, projetileInstantiatePos.position, Quaternion.identity);
                    StartCoroutine(Wait(atackSpeed));
                }
            }

            

            for (int i = 0; i < enemiesInRange.Count; i++)
            {
                if (enemiesInRange[i] != null)
                {
                    if (Vector2.Distance(transform.position, enemiesInRange[i].transform.position) > 3)
                    {
                        enemiesInRange.Remove(enemiesInRange[i]);
                    }
                }
                else if (enemiesInRange[i] == null)
                {
                    enemiesInRange.Remove(enemiesInRange[i]);
                }
            }
        } else if(enemiesInRange.Count <= 0)
        {
            towerGun.transform.rotation = Quaternion.Lerp(towerGun.transform.rotation, Quaternion.identity, qSpeed * Time.deltaTime);
        }
    }

    IEnumerator Wait(float atackSpeed)
    {
        isAtacking = true;
        yield return new WaitForSeconds(atackSpeed);
        isAtacking = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            enemiesInRange.Add(collision.gameObject);
        }
    }
}

