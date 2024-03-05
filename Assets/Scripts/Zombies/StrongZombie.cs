using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrongZombie : Zombie
{
    public GameObject ClawsStrong;
    public override void AttackControl()
    {
        ClawsStrong.SetActive(true);
        
    }
    public override void StopAttack()
    {
        ClawsStrong.SetActive(false);
    }
}
