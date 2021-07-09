using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    private int score = 0;
    public int Score
    {
        get
        {
            return score;
        }
        set
        {
            score = value;
            scoreText.text = $"Score:{score}";
        }
    }
    
    [SerializeField] private Text scoreText = null;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
