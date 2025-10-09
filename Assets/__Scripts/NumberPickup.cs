using UnityEngine;

public class NumberPickup : MonoBehaviour
{
    public int value;
    public TextMesh numberText;

    void Start()
    {
        ResetNumber();
    }

    // Assigns a new random number
    public void ResetNumber()
    {
        value = Random.Range(1, 10);
        if (numberText != null){
            numberText.text = value.ToString();
            gameObject.SetActive(false);
            yeild return new WaitForSeconds(3f);
        }
        gameObject.SetActive(true); // always visible
    }

    // Called when player collects it
    public void Collect()
    {
        ResetNumber(); // immediately assign new number instead of hiding
    }
}

