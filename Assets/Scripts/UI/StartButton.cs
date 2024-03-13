using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButton : MonoBehaviour
{
    public UIManager uiManager;
    public void OnStartOnClick()
    {
        uiManager.StartGame();
    }
}
