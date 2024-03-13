using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject TutorialMenu;
    public void StartGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void TutorialPage()
    {
        TutorialMenu.SetActive(true);
        gameObject.SetActive(false);
    }

    public void ReturnPage()
    {
        TutorialMenu.SetActive(false);
        gameObject.SetActive(true);
    }
}
