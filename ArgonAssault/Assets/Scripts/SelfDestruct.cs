using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{

    float delayDestroy = 3f;

    private void Start()
    {
        Destroy(gameObject, delayDestroy);
    }

}
