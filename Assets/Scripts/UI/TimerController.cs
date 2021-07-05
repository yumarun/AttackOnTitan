using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerController : MonoBehaviour
{
    public float Timer = 0;


    [SerializeField] Text TimerText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        Timer += Time.deltaTime;

        TimerText.text = $"Time:{Timer}";
    }
}
