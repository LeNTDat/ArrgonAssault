using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;

public class TriggerPlasma : MonoBehaviour
{
    bool isShoot = false;
    ParticleSystem.EmissionModule Emission;

    void Start()
    {
        Emission = gameObject.GetComponent<ParticleSystem>().emission;
        InvokeRepeating("ShootingPlasma", 2f, 10f);
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void ShootingPlasma() {
        int canShoot = Random.Range(0, 2);
        if(canShoot < 1) {
            Emission.enabled = true;
        }
    }

}
