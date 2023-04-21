using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject EnemyExlode;
    [SerializeField] Transform Parent;
    private void OnParticleCollision(GameObject other)
    {
        GameObject VFx = Instantiate(EnemyExlode, transform.position, Quaternion.identity);
        VFx.transform.parent = Parent;
        Destroy(gameObject);
    }
}
