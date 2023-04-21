using UnityEngine;

public class ColliderCheck : MonoBehaviour
{
    [SerializeField] ParticleSystem ShipExlode;
    
    private void OnTriggerEnter(Collider other)
    {
        Transform[] allChildren = GetComponentsInChildren<Transform>();
        foreach (Transform child in allChildren)
        {
            if(child.tag == "Player")
            {
                child.GetComponent<MeshRenderer>().enabled = false;
            }
        }
        ShipExlode.GetComponent<ParticleSystem>().Play();
        GameManager.instance.GameOver();
    }
}
