using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public static Action OnCoinCollected;

    [NonSerialized] public int coins = 0;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        OnCoinCollected += () => { coins++; };
    }
}
