using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountZombieDeaths : MonoBehaviour
{
    public int countDies = 0;
    private MoreTimeManagement moreTime;
    public HudManagment hud;

    private void Start()
    {
        moreTime = GameObject.Find("SpawnerAddOnTime").GetComponent<MoreTimeManagement>();
        hud = GameObject.Find("HUD").GetComponent<HudManagment>();
    }

    public void ZombieDies()
    {
        countDies++;
        print(countDies);
        if (countDies % 3 == 0)
        {
            moreTime.ActiveAddOn();
            
        }

        if(countDies == 12)
        {
            hud.WinFinal();
            
        }
    }
}
