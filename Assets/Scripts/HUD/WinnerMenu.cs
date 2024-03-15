using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinnerMenu : MonoBehaviour
{
    public GameObject winMenu;
    public void Winner()
    {
        winMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void ExitTheGame()
    {
        Application.Quit();
    }
}
