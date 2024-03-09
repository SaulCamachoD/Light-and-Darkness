using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerLight : MonoBehaviour
{
    public float inicialTime = 30f;
    public float restTime;
    void Start()
    {
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
            print("las luz se acabo");
        }
    }

    public void AddTime()
    {
        restTime += 30f;
        print("tiempo anadido");
        
    }
}
