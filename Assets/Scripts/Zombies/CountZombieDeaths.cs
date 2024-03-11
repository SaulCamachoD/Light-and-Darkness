using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountZombieDeaths : MonoBehaviour
{
    [SerializeField] int countDies = 0;
    private MoreTimeManagement moreTime;

    private void Start()
    {
        moreTime = GameObject.Find("SpawnerAddOnTime").GetComponent<MoreTimeManagement>();
    }

    public void ZombieDies()
    {
        countDies++;
        print(countDies);
        if (countDies == 7)
        {
            moreTime.ActiveAddOn();
        }
    }
}
