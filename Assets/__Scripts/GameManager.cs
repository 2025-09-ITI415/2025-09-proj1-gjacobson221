using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("UI")]
    public Text sumText;       // Shows current sum
    public Text targetText;    // Shows target number
    public Text messageText;   // Shows feedback/win/lose message

    [Header("Game State")]
    public int currentSum = 0;
    public int targetNumber = 0;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {
        ResetRound();
    }

    public void AddToSum(int value)
    {
        currentSum += value;
        UpdateUI();

        if (currentSum == targetNumber)
        {
            messageText.text = "You win!";
            StartCoroutine(ResetAfterDelay(3f));
        }
        else if (currentSum > targetNumber)
        {
            messageText.text = "You lose!";
            StartCoroutine(ResetAfterDelay(3f));
        }
    }

    public void UpdateUI()
    {
        if (sumText != null)
            sumText.text = "Sum: " + currentSum;
        if (targetText != null)
            targetText.text = "Target: " + targetNumber;
    }

    public void ResetRound()
    {
        currentSum = 0;
        targetNumber = Random.Range(10, 51);
        if (messageText != null)
            messageText.text = "";
        UpdateUI();

        // Reset all pickups with new numbers
        NumberPickup[] pickups = FindObjectsOfType<NumberPickup>();
        foreach (NumberPickup pickup in pickups)
            pickup.ResetNumber();

        // Reset player to center
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            player.transform.position = Vector3.zero;
            Rigidbody rb = player.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.velocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
            }
        }
    }

    private IEnumerator ResetAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        ResetRound();
    }
}