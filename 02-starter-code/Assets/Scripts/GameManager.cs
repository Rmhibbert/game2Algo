using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public UnityEvent OnGoldSet = new UnityEvent();
    public int StartingGold = 1000;// Arbitrary starting value. 
    private int gold;
    public bool gameOver = false;
    public UnityEvent OnHealthSet = new UnityEvent();
    public UnityEvent OnGameOver = new UnityEvent();
    private int health;
    public int Health
    {
        get { return health; }
        set
        {
            health = value;
            OnHealthSet?.Invoke();
            if (health <= 0 && !gameOver)
            {
                OnGameOver?.Invoke();
                gameOver = true;
            }
        }
    }
    public int Gold
    {
        get { return gold; }
        set
        {
            gold = value;
            // Anything in our game can hook into this event and run a function whenever the gold
            // changes.
            OnGoldSet?.Invoke();
        }
    }

    private void Awake()
    {
        // Just ensures there can only ever be one instance of Game Manager.
        if (Instance != null)
        {
            Destroy(this);
            return;
        }
        Instance = this;
    }

    private void Start()
    {
        Gold = StartingGold;
        Health = 5;
    }

    public void DecreaseHealth(int amount)
    {
        Health -= amount;
    }
}
