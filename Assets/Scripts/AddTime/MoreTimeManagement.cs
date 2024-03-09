using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoreTimeManagement : MonoBehaviour
{
    public GameObject AddOn1;
    public GameObject AddOn2;
    public GameObject AddOn3;
    private int numMax = 4;
    private int numMin = 1;
    

    public void ActiveAddOn()
    {
        int randonNum = Random.Range(numMin, numMax);
        print(randonNum);
        switch (randonNum) 
        {
            case 1:
                AddOn1.SetActive(true);
                break;
            case 2:
                AddOn2.SetActive(true);
                break;
            case 3:
                AddOn3.SetActive(true);
                break;
            default:
                AddOn1.SetActive(false);
                AddOn2.SetActive(false);
                AddOn3.SetActive(false);
                break;

        }
    }
}
