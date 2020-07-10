using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DoorController : MonoBehaviour
{
    [SerializeField] private float downTo = -1.5f;
    [SerializeField] private float smoothFactor = 2f;

    [SerializeField] private int coinsToOpen;

    [SerializeField] private Text coinsToOpenLabel;
    [SerializeField] private GameObject canvas;


    private void Start()
    {
        coinsToOpenLabel.text = coinsToOpen.ToString();

        GameManager.OnCoinCollected += () =>
        {
            if (GameManager.Instance.coins == coinsToOpen) { StartCoroutine(openDoor()); }
        };
    }

    private IEnumerator openDoor()
    {
        while (transform.position.y > downTo)
        {
            float posY = Mathf.Lerp(transform.position.y, downTo - 1, Time.deltaTime * smoothFactor);
            transform.position = new Vector3(transform.position.x, posY, transform.position.z);

            yield return null;
        }
        canvas.SetActive(false);
    }
}
