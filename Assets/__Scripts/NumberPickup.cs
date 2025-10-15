using UnityEngine;
using System.Collections;

public class NumberPickup : MonoBehaviour
{
    public int value;
    public TextMesh numberText;
    private Collider col;

    void Start()
    {
        // Auto-assign TextMesh if not linked in Inspector
        if (numberText == null)
            numberText = GetComponentInChildren<TextMesh>();

        col = GetComponent<Collider>();
        ResetNumber();
    }

    public void ResetNumber()
    {
        value = Random.Range(1, 10);

        if (numberText != null)
            numberText.text = value.ToString();

        if (numberText != null)
            numberText.gameObject.SetActive(true);

        if (col != null)
            col.enabled = true;
    }

    public void Collect()
    {
        // hide the number visually and disable collider
        if (numberText != null)
            numberText.gameObject.SetActive(false);

        if (col != null)
            col.enabled = false;

        // start coroutine *before* disabling the object
        StartCoroutine(RespawnAfterDelay(3f));
    }

    private IEnumerator RespawnAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        ResetNumber();
        if (numberText != null)
            numberText.gameObject.SetActive(true);
        if (col != null)
            col.enabled = true;
    }

}

