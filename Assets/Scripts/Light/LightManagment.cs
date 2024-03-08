using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightManagment : MonoBehaviour
{
    public GameObject Light;
    public GameObject Player;
        void Update()
    {
        Vector3 playerPosition = Player.transform.position;
        Light.transform.position = new Vector3(playerPosition.x, playerPosition.y + 10, playerPosition.z);
    }
}
