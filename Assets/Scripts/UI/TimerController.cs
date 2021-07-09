using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class TimerController : MonoBehaviour
{
    public float timer = 0;
    
    [FormerlySerializedAs("TimerText")] [SerializeField] private Text timerText = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        timerText.text = $"Time:{timer}";
    }
}
