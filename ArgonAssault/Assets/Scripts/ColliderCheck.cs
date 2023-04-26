using UnityEngine;

public class ColliderCheck : MonoBehaviour
{
    [SerializeField] ParticleSystem ShipExlode;
    [SerializeField] int ShipHitPoint = 5;
    [SerializeField] int ShipScore = 20;
    Enemy enemy;

    void Start()
    {
        enemy = GetComponent<Enemy>();
    }
    private void OnTriggerEnter(Collider other)
    {
        ExplodeShip();
    }

    void ExplodeShip()
    {
        Transform[] allChildren = GetComponentsInChildren<Transform>();
        foreach (Transform child in allChildren)
        {
            if (child.tag == "Player")
            {
                child.GetComponent<MeshRenderer>().enabled = false;
            }
        }
        ShipExlode.GetComponent<ParticleSystem>().Play();
        GameManager.instance.GameOver();
    }
}
