using UnityEngine;

public class SmallThingsRandomizer : MonoBehaviour
{
    private void Start()
    {
        int childsToSave = Random.Range(1, transform.childCount);

        while (transform.childCount > childsToSave)
        {
            Transform childToDestroy = transform.GetChild(Random.Range(0, transform.childCount));
            DestroyImmediate(childToDestroy.gameObject);
        }
    }
}
