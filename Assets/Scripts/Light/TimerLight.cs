using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerLight : MonoBehaviour
{
    public float inicialTime = 90f;
    public float restTime;
    public HudManagment hud;
    void Start()
    {
        hud = GameObject.Find("HUD").GetComponent<HudManagment>();
        restTime = inicialTime;
    }

    
    void Update()
    {
        if (restTime > 0)
        {
            restTime -= Time.deltaTime;
            
        }
        else
        {
            hud.Finished();
        }
    }

    public void AddTime()
    {
        restTime += 30f;
        
    }
}
