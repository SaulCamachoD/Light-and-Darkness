using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnButton : MonoBehaviour
{
    public UIManager uiManager;

    public void OnReturnButtonClick()
    {
        uiManager.ReturnPage();
    }
}
