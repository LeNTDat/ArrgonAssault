using UnityEngine;

public class ColliderCheck : MonoBehaviour
{
    [SerializeField] ParticleSystem ShipExlode;
    [SerializeField] int ShipHitPoint = 50;
    [SerializeField] int ShipScore = 20;

    private void OnTriggerEnter(Collider other)
    {
        ExplodeShip();
        CountHitPointExplode(other);
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

    void CountHitPointExplode(Collider other) {
        Enemy enemy = other.GetComponent<Enemy>();
        enemy.ProcessHit(ShipScore, ShipHitPoint);
        if (enemy.HitPoint <= 0)
        {
            enemy.DestroyEnemy();
        }
    }
}
