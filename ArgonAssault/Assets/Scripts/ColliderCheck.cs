using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderCheck : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        print(this.name + "is explose");
    }

    private void OnTriggerEnter(Collider other)
    {
        GameManager.instance.GameOver();
        print("Here");
    }
}
