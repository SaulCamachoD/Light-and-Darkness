using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FailedMenu : MonoBehaviour
{
    public GameObject loseMenu;
    public void Fail()
    {
        loseMenu.SetActive(true);
        Time.timeScale = 0f;
    }
}
