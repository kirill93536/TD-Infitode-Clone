using UnityEngine;

public class BuyTowerByRay : MonoBehaviour
{
    [SerializeField] GameObject tower;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        LayerMask mask = LayerMask.GetMask("BuyTile");
        //If the left mouse button is clicked.
        if (Input.GetMouseButtonDown(0))
        {
            //Get the mouse position on the screen and send a raycast into the game world from that position.
            Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero, Mathf.Infinity, mask);

            if(hit.collider != null)
            {
                //If something was hit, the RaycastHit2D.collider will not be null.
                if (hit.collider.tag == "TileForTower")
                {
                    Instantiate(tower, hit.collider.gameObject.transform.position, Quaternion.identity);
                    hit.collider.tag = "TowerPlaced";
                }
                else
                {
                    Debug.Log("No ray point");
                }
            }
        }
    }
}


