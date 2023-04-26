using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    
    [SerializeField] float delayDestroy;

    private void Start()
    {
        Destroy(gameObject, delayDestroy);
    }

}
