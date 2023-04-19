using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class GameManager : MonoBehaviour
{
    public bool isStart = false;
    public bool isgameOver = false;

    PlayableDirector play;

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
        play = GameObject.Find("Master Timeline").GetComponent<PlayableDirector>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameOver() {
        isgameOver = true;
        play.Stop();
    }
}
