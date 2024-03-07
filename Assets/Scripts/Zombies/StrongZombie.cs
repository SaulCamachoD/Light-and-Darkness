using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrongZombie : Zombie
{
    public GameObject ClawsStrong;

    protected override void Start()
    {
        base.Start();
    }
    public override void AttackControl()
    {
        ClawsStrong.SetActive(true);
        
    }
    public override void StopAttack()
    {
        ClawsStrong.SetActive(false);
    }

    protected override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);

        if (other.CompareTag("Blades"))
        {
            animator.SetTrigger("GetHit");
        }
    }
}
