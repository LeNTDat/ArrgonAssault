using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] TMP_Text sCore;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        showScore();
    }

    void showScore() { 
        sCore.text = ScoreManager.instance.score.ToString();
    }
}
