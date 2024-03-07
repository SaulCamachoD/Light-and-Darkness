using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalZombie : Zombie
{
    public GameObject CrawColider;
    public override void AttackControl()
    {
        CrawColider.SetActive(true);

    }
    public override void StopAttack()
    {
        CrawColider.SetActive(false);
    }
}
