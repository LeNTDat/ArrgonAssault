using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    // Start is called before the first frame update

    private void Start()
    {
        InvokeRepeating("clearChild", 3f, 5f);
    }

    private void Update()
    {
        
    }
    void clearChild () {
        Transform[] ts = GetComponentsInChildren<Transform>();
        foreach (var item in ts)
        {
            if (item.tag == "VFX")
            {
                Destroy(item.gameObject);
            }
        }
    }
}
