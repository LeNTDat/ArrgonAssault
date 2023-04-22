using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int score;
    public static ScoreManager instance;



    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    public void IncrementScore (int scoreOfObj) 
    {
        score += scoreOfObj;
    }

    
}
