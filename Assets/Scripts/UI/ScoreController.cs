using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    int score = 0;
    public int Score
    {
        get
        {
            return score;
        }
        set
        {
            score = value;
            ScoreText.text = $"Score:{score}";


        }
    }


    [SerializeField] Text ScoreText;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
