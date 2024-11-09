using UnityEngine;

public class EnemyParams : MonoBehaviour
{
    public bool isAlive = true;
    public int lives = 1000;

    [SerializeField] float speed = 4.0f;
    [SerializeField] Transform[] wayPoints;

    public Transform enemyPosition
    {
        get { return transform; }
    }

    int wayPointIndex = 0;

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        if (wayPointIndex <= wayPoints.Length - 1)
        {
            transform.position = Vector2.MoveTowards
                (transform.position, wayPoints[wayPointIndex].position, speed * Time.deltaTime);

            if (transform.position == wayPoints[wayPointIndex].position)
            {
                wayPointIndex++;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        /*if (collision.tag == "Projectile")
        {
            lives--;
            if (lives == 0)
            {
                Destroy(gameObject);
            }
        }*/

        if (collision.tag == "Finish")
        {
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        /*
         Debug.Log("Destroyed");
        for(int i = 0; i < TowerAtack.enemiesInRange.Count; i++)
        {
            if(TowerAtack.enemiesInRange[i] == gameObject)
            {
                TowerAtack.enemiesInRange.Remove(TowerAtack.enemiesInRange[i]);
            }
        }
        */
    }
}