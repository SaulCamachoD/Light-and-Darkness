using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class HealthBar : MonoBehaviour
{
    public HudManagment hud;
    public UnityEngine.UI.Image Healthbar;
    

    void Start()
    {
        hud = GameObject.FindGameObjectWithTag("Hud").GetComponent<HudManagment>();
        Healthbar.fillAmount = 1.0f;
    }

    // Update is called once per frame
    void Update()
    { 
        float fillAmount = hud.health / hud.maxhealth; 
        Healthbar.fillAmount = fillAmount;
    }
}
