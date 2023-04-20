using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Android;

public class ColliderCheck : MonoBehaviour
{
    [SerializeField] GameObject ShipExlode;

    private void OnTriggerEnter(Collider other)
    {
        gameObject.GetComponentInChildren<MeshRenderer>().enabled = false;
        ShipExlode.GetComponent<ParticleSystem>().Play();
        GameManager.instance.GameOver();
    }
}
