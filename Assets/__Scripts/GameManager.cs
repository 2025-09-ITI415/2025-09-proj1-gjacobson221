using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public Text targetText;
    public Text sumText;
    public Text messageText;

    private int targetNumber;
    private int currentSum;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        StartNewRound();
    }

    public void StartNewRound()
    {
        currentSum = 0;
        targetNumber = Random.Range(10, 50);

        NumberPickup[] pickups = FindObjectsOfType<NumberPickup>();
        foreach (NumberPickup pickup in pickups)
        {
            pickup.AssignRandomValue();
            pickup.gameObject.SetActive(true);
        }

        messageText.text = "";
        UpdateUI();
    }

    public void AddToSum(int value, GameObject pickup)
    {
        currentSum += value;
        UpdateUI();

        if (currentSum == targetNumber)
        {
            messageText.text = "You Win!";
        }
        else if (currentSum > targetNumber)
        {
            messageText.text = "Too High!";
        }

        pickup.SetActive(false);
    }

    void UpdateUI()
    {
        targetText.text = "Target: " + targetNumber;
        sumText.text = "Sum: " + currentSum;
    }
}