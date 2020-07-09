using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public static Action OnCoinCollected;

    private void Awake()
    {
        Instance = this;
    }
}
