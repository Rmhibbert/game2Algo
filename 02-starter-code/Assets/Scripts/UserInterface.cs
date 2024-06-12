using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;


public class UserInterface : MonoBehaviour
{
    public EnemySpawner EnemySpawner;
    [SerializeField] private Text goldLabel;
    [SerializeField] private Text waveLabel;
    [SerializeField] private Text healthLabel;
    [SerializeField] private Animator topHalfWaveStartLabel;
    [SerializeField] private Animator bottomHalfWaveStartLabel;
    [SerializeField] private Animator GameOverLabel;
    private void Awake()
    {
        GameManager.Instance.OnHealthSet.AddListener(HandleHealthSet);
        GameManager.Instance.OnGoldSet.AddListener(HandleGoldSet);
        EnemySpawner.OnWaveStarted.AddListener(HandleWaveStarted);
        GameManager.Instance.OnGameOver.AddListener(HandleGameEnd);

    }

    private void HandleGoldSet()
    {
        goldLabel.text = "GOLD: " + GameManager.Instance.Gold.ToString();
    }

    private void HandleHealthSet()
    {
        healthLabel.text = "HEALTH: " + GameManager.Instance.Health.ToString();
    }

    private void HandleWaveStarted()
    {
        waveLabel.text = "WAVE: " + (EnemySpawner.currentWaveIndex + 1).ToString();
        // Fire off the animation for both label halves. When played at the same time, these
        // create a flashy effect.
        topHalfWaveStartLabel.SetTrigger("nextWave");
        bottomHalfWaveStartLabel.SetTrigger("nextWave");
    }
    private void HandleGameEnd()
    {
        GameOverLabel.SetTrigger("gameOver");
    }
}