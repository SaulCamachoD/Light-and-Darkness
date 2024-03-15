using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoreTime : MonoBehaviour
{
    public GameObject timerLightObject;
    public GameObject addTime;
    public HealthAndDamage addHealth;
    private TimerLight timerLight;
     


    private void Start()
    {
        timerLight = timerLightObject.GetComponent<TimerLight>();
        addHealth = GameObject.Find("Player").GetComponent<HealthAndDamage>();

    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            timerLight.AddTime();
            addHealth.AddHealt();
            print("funciona");
            addTime.SetActive(false);
        }
    }
}
