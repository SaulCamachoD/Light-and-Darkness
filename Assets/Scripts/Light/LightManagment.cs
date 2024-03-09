using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightManagment : MonoBehaviour
{
    public GameObject LightObject;
    public GameObject Player;
    public TimerLight timerLight;
    public float minIntensity = 0f;
    public float maxIntensity = 1000f;
    private Light lightObject;

    private void Start()
    {
        lightObject = GetComponent<Light>();
    }
    void Update()
    {
        Vector3 playerPosition = Player.transform.position;
        LightObject.transform.position = new Vector3(playerPosition.x, playerPosition.y + 10, playerPosition.z);
        LightTime();
    }

    private void LightTime()
    {
        // Me interpola el valor de tiempo de 0 a 1
        float normalizedTime = Mathf.Clamp01(timerLight.restTime / timerLight.inicialTime);

        // me interpola el valor de intensidad  de 0 a 1 con el valor interpolado anterior
        float interpolatedIntensity = Mathf.Lerp(minIntensity, maxIntensity, normalizedTime);

        // Asigna la intensidad interpolada a la luz
        lightObject.intensity = interpolatedIntensity;
    }
}

