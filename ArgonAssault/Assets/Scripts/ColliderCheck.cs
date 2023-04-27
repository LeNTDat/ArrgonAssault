using UnityEngine;

public class ColliderCheck : MonoBehaviour
{
    [SerializeField] GameObject ShipExlode;
    [SerializeField] int ShipHitPoint = 5;
    [SerializeField] int ShipScore = 20;
    Transform parent;

    void Start()
    {
        parent = GameObject.FindWithTag("SpawnAtRunTime").transform;
    }
    void OnTriggerEnter(Collider other)
    {
        ExplodeShip();
    }

    public void ExplodeShip()
    {
        Transform[] allChildren = GetComponentsInChildren<Transform>();
        foreach (Transform child in allChildren)
        {
            if (child.tag == "Player")
            {
                child.GetComponent<MeshRenderer>().enabled = false;
            }
        }
        GameObject fx = Instantiate(ShipExlode, transform.position, Quaternion.identity);
        fx.transform.parent = parent;   
        GameManager.instance.GameOver();
    }

}
