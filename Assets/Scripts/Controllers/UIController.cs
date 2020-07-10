using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private Text coinsCounter;

    [SerializeField] private Text text;

    private void Start()
    {
        GameManager.OnCoinCollected += UpdateCoinsLabel;
        GameManager.OnCheckpoint += () =>
        {
            StartCoroutine(OnCheckPoint());
        };
        GameManager.OnFinish += () =>
        {
            StartCoroutine(OnFinish());
        };
    }

    private void UpdateCoinsLabel()
    {  
        coinsCounter.text = GameManager.Instance.coins.ToString();
    }

    private IEnumerator OnCheckPoint()
    {
        float a = 0;
        
        while (a < 1)
        {
            a += 0.01f;
            text.color = new Color(text.color.r, text.color.g, text.color.b, a);

            yield return null;
        }

        while (a > 0)
        {
            a -= 0.01f;
            text.color = new Color(text.color.r, text.color.g, text.color.b, a);

            yield return null;
        }
    }

    private IEnumerator OnFinish()
    {
        float a = 0;

        text.text = "FINISHED!";

        while (a < 1)
        {
            a += 0.01f;
            text.color = new Color(text.color.r, text.color.g, text.color.b, a);

            yield return null;
        }

        while (a > 0)
        {
            a -= 0.01f;
            text.color = new Color(text.color.r, text.color.g, text.color.b, a);

            yield return null;
        }

        SceneManager.LoadScene(0);
    }
}
