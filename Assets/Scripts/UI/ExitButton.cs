using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitButton : MonoBehaviour
{
    public UIManager uiManager;

    public void OnExitButtonClick()
    {
        uiManager.ExitGame();
    }
}
