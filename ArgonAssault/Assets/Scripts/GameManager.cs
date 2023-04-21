using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool isStart = false;
    public bool isgameOver = false;
    float loadDelay = 1.5f;


    public static GameManager instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void reStartLevel()
    {
        SceneManager.LoadScene(0);
    }

    public void GameOver() {
        isgameOver = true;
        Invoke("reStartLevel", loadDelay);
    }
}
