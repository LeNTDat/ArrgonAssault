using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject EnemyExlode;
    [SerializeField] GameObject HitVFX;
    [SerializeField] Transform Parent;
    [SerializeField] int scorePerHit = 15;
    [SerializeField] int DamagePerHit = 10;
    public int HitPoint;
    private void OnParticleCollision(GameObject other)
    {
        GameObject vFx = Instantiate(HitVFX, transform.position, Quaternion.identity);
        vFx.transform.parent = Parent;
        ProcessHit(scorePerHit, DamagePerHit);
        if (HitPoint <= 0) {
            DestroyEnemy();
        }
    }

    public void DestroyEnemy() {
        GameObject VFx = Instantiate(EnemyExlode, transform.position, Quaternion.identity);
        VFx.transform.parent = Parent;
        Destroy(gameObject);
    }

    public void ProcessHit(int score, int Damage)
    {
        
        ScoreManager.instance.IncrementScore(score); 
        HitPoint -= Damage;
    }

}
