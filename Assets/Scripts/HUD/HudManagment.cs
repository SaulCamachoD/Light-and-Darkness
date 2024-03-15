using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HudManagment : MonoBehaviour
{
    public TimerLight timerLight;
    public HealthAndDamage healthAndDamage;
    public CountZombieDeaths dies;
    public ScoreView scoreView;
    public PauseMenu pauseMenu;
    public FailedMenu lose;
    public WinnerMenu win;
    public float totalTime;
    public float currentTime;
    public float health;
    public float maxhealth;
    public int zombieDies;
    private void Start()
    {
        maxhealth = healthAndDamage.maxHealth;
        timerLight = GameObject.FindGameObjectWithTag("Light").GetComponent<TimerLight>();
        healthAndDamage = GameObject.FindGameObjectWithTag("Player").GetComponent<HealthAndDamage>();
        dies = GameObject.FindGameObjectWithTag("Dies").GetComponent<CountZombieDeaths>();
        pauseMenu = GameObject.FindGameObjectWithTag("Pause").GetComponent<PauseMenu>();
        lose = GameObject.FindGameObjectWithTag("Lose").GetComponent<FailedMenu>();
        win = GameObject.FindGameObjectWithTag("Win").GetComponent<WinnerMenu>();
        scoreView = GetComponent<ScoreView>();
    }

    public void Update()
    {
        totalTime = timerLight.inicialTime;
        currentTime = timerLight.restTime;
        health = healthAndDamage.health;
        zombieDies = dies.countDies;
        scoreView.Score(zombieDies);

        if(Input.GetKey(KeyCode.P)) 
        {
            pauseMenu.Pause();
        }
    }

    public void Finished()
    {
        lose.Fail();
    }

    public void WinFinal()
    {
        win.Winner();
    }
}
