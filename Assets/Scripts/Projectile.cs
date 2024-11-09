using System;
using System.Collections;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [Header("Скорость движения")]
    [Header("Движение проджектайла скрипт")]

    public float speed = 5f;

    Collider2D[] parentTowerSearchArray;
    float searchRadius = 0.15f;
    bool isDestroyed = false;
    GameObject targetObj;
    public int lives;

    private void Start()
    {
        parentTowerSearchArray = Physics2D.OverlapCircleAll(transform.position, searchRadius);
        foreach (var item in parentTowerSearchArray)
        {
            if(item.tag == "Tower")
            {
                if(item.gameObject.GetComponent<TowerAtack>().enemiesInRange.Count > 0)
                {
                    Debug.Log("target");
                    TargetAdd tempTarget = new TargetAdd(item.gameObject.GetComponent<TowerAtack>().enemiesInRange[0]);
                    targetObj = tempTarget.ReturnTarget();
                }
                
            }
        }
    }

    private void Update()
    {
        if (targetObj != null)
        {
            Move(targetObj.transform);
        }
        else if (targetObj == null && !isDestroyed)
        {
            isDestroyed = true;
            Debug.Log("Destroyed");
            Destroy(gameObject);
            //StartCoroutine(WaitBeforeDestroy());
        }
    }

    IEnumerator WaitBeforeDestroy()
    {
        //System.Random rand = new System.Random();
        //float waitTime = (float)(rand.Next(1, 10)) / 100;
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }

    void Move(Transform targetPos)
    {
        //this.target = target;
        transform.position = Vector2.MoveTowards(transform.position, targetPos.position, speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.transform == targetObj.transform)
        {
            
            if(targetObj.GetComponent<EnemyParams>().lives != 0)
            {
                targetObj.GetComponent<EnemyParams>().lives--;
                Destroy(gameObject);
            }
            if(targetObj.GetComponent<EnemyParams>().lives == 0)
            {
                Destroy(collision.gameObject);
                Destroy(gameObject);
                
            }
        }
    }
}