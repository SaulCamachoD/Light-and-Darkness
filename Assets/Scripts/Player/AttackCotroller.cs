using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCotroller : MonoBehaviour
{
    [SerializeField] private float playerHitForce = 10f;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Zombie"))
        {
            ZombieController controller = other.GetComponent<ZombieController>();

            Vector3 hitDirection = other.transform.position - gameObject.transform.position ;

            hitDirection = hitDirection.normalized ;

            controller.ApplyHitForce(hitDirection * playerHitForce);

            print(hitDirection);
            
        }
    }
}
