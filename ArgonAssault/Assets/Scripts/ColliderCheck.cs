using UnityEngine;

public class ColliderCheck : MonoBehaviour
{
    [SerializeField] ParticleSystem ShipExlode;
    [SerializeField] int ShipHitPoint = 5;
    [SerializeField] int ShipScore = 20;

    private void OnTriggerEnter(Collider other)
    {
        ExplodeShip();
        print(other.tag);
        Enemy enemy = other.GetComponent<Enemy>();
        enemy.ProcessHit(ShipScore);
        if ((enemy.HitPoint - ShipHitPoint) <= 0)
        {
            enemy.DestroyEnemy();
        }
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
