using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    void Awake()
    {
        int NumOfMusicPlayer = FindObjectsOfType<MusicManager>().Length;
        if (NumOfMusicPlayer > 1)
        {
            Destroy(gameObject);
        }
        else { 
            DontDestroyOnLoad(gameObject);
        }
    }
}
