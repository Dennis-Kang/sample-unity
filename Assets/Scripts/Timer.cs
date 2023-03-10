using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI text;
    float startTime;
    float currentTime;

    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
    }

    void Update()
    {
        currentTime = (Time.time - startTime);
        currentTime = System.MathF.Round(currentTime, 2);

        text.text = currentTime.ToString();
    }
}
