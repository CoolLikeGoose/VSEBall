using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private Text coinsCounter;

    private void Start()
    {
        GameManager.OnCoinCollected += UpdateCoinsLabel;
    }

    private void UpdateCoinsLabel()
    {  
        coinsCounter.text = GameManager.Instance.coins.ToString();
    }
}
