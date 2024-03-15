using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.UI;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine.UI;

public class LightBar : MonoBehaviour
{
    public Slider Lightbar;
    public HudManagment hud;
    public float totalTime;
    public float currentTime;

    void Start()
    {
        hud = GameObject.FindGameObjectWithTag("Hud").GetComponent<HudManagment>();
        
    }

    public void Update()
    {
        totalTime = hud.totalTime;
        currentTime = hud.currentTime;

        Lightbar.maxValue = totalTime;
        Lightbar.value = currentTime;
    }
}
