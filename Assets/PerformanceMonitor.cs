using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PerformanceMonitor : MonoBehaviour
{

    public TMP_Text fpsText;
    private int frameCount;
    private float elapsedTime;
    private float fps;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;
        frameCount++;

        if (elapsedTime > 1.0f)
        {
            fps = frameCount / elapsedTime;
            frameCount = 0;
            elapsedTime = 0;
        }

        fpsText.text = $"FPS: {fps}";
    }
}
