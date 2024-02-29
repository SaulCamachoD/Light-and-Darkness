using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthAndDamage : MonoBehaviour
{
    public int health = 100;

    void Start()
    {
        
    }

    public void TakeDamege(int damage)
    {
        print("has recive damage the:" + damage);
    }
}
