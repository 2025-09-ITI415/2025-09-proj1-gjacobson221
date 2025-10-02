using UnityEngine;

public class NumberPickup : MonoBehaviour
{
    public int value;
    private TextMesh textMesh;

    void Start()
    {
        textMesh = GetComponent<TextMesh>();
        AssignRandomValue();
    }

    public void AssignRandomValue()
    {
        // Random number between 1 and 9
        value = Random.Range(1, 10);

        if (textMesh != null)
        {
            textMesh.text = value.ToString();
        }
    }

    void LateUpdate()
    {
        // Keep number facing the camera
        if (Camera.main != null)
        {
            transform.rotation = Camera.main.transform.rotation;
        }
    }
}
