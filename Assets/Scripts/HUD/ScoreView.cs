using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreView : MonoBehaviour
{
    [SerializeField] private TMP_Text score;

    public void Score(int dies)
    {
       score.text = $"Score {dies}";
    }
}
