using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.Burst.Intrinsics.X86;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject EnemyExlode;
    [SerializeField] GameObject HitVFX;
    [SerializeField] int scorePerObj = 15;
    public int HitPoint;
    Transform Parent;
    Rigidbody rb;

    void Start()
    {
        rb = gameObject.AddComponent<Rigidbody>();
        rb.useGravity = false;
        rb.isKinematic = true;
        Parent = GameObject.FindWithTag("SpawnAtRunTime").transform;
    }

    void OnParticleCollision(GameObject other)
    {
        ProcessHit(scorePerObj);
        if (HitPoint <= 0) {
            DestroyEnemy();
        }
    }

    public void DestroyEnemy() {
        GameObject Fx = Instantiate(EnemyExlode, transform.position, Quaternion.identity);
        Fx.transform.parent = Parent;
        Destroy(gameObject);
    }

    public void ProcessHit(int score)
    {
        GameObject vFx = Instantiate(HitVFX, transform.position, Quaternion.identity);
        vFx.transform.parent = Parent;
        ScoreManager.instance.IncrementScore(score); 
        HitPoint--;
    }

}
