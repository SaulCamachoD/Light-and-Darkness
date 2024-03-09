using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoreTime : MonoBehaviour
{
    public GameObject timerLightObject;
    public GameObject addTime;
    private TimerLight timerLight;
     


    private void Start()
    {
        timerLight = timerLightObject.GetComponent<TimerLight>();
        
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            timerLight.AddTime();
            print("funciona");
            addTime.SetActive(false);
        }
    }
}
