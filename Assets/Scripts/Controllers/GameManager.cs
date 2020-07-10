using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public static Action OnCoinCollected;
    public static Action OnRoundLose;
    public static Action OnCheckpoint;
    public static Action OnFinish;

    [NonSerialized] public int coins = 0;

    private void Awake()
    {
        Instance = this;
        OnCoinCollected += () => { coins++; };
    }

    private void OnDestroy()
    {
        OnCoinCollected = null;
        OnRoundLose = null;
        OnCheckpoint = null;
        OnFinish = null;
    }

    //Garbage collector
    private void OnTriggerEnter(Collider other)
    {
        OnRoundLose();
    }
}
