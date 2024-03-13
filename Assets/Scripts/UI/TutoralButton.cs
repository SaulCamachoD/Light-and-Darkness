using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutoralButton : MonoBehaviour
{
    public UIManager uiManager;

    public void OnTutorialButtonClick()
    {
        uiManager.TutorialPage();
    }
}
