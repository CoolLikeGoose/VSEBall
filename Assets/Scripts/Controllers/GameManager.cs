using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public static Action OnCoinCollected;
    public static Action OnRoundLose;

    [NonSerialized] public int coins = 0;

    private void Awake()
    {
        Instance = this;
        OnCoinCollected += () => { coins++; };
    }

    //Garbage collector
    private void OnTriggerEnter(Collider other)
    {
        OnRoundLose();
    }
}
