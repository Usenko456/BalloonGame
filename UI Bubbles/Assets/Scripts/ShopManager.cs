using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public static ShopManager Instance;

    public Sprite[] balloonSprites;
    public int[] prices;
    public Button[] balloonButtons;
    public TMP_Text[] priceTexts;
    public TMP_Text coinsText;

    private int coins;
    private const string CoinsKey = "PlayerCoins";
    private const string SelectedKey = "SelectedBalloonSprite";

    public int Coins => coins;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {
        coins = PlayerPrefs.GetInt(CoinsKey, 200);
        UpdateCoinsUI();

        for (int i = 0; i < balloonButtons.Length; i++)
        {
            int index = i;
            bool isPurchased = IsBalloonPurchased(index);
            priceTexts[i].text = isPurchased ? "SOLD" : prices[i] + "💰";
            balloonButtons[i].onClick.AddListener(() => OnBalloonButton(index));
        }
    }

    public void AddCoins(int amount)
    {
        coins += amount;
        PlayerPrefs.SetInt(CoinsKey, coins);
        PlayerPrefs.Save();
        UpdateCoinsUI();
    }

    public bool IsBalloonPurchased(int index)
    {
        return PlayerPrefs.GetInt("BalloonBought_" + index, 0) == 1;
    }

    void OnBalloonButton(int index)
    {
        bool isPurchased = IsBalloonPurchased(index);

        if (isPurchased)
        {
            PlayerPrefs.SetInt(SelectedKey, index);
            PlayerPrefs.Save();
            Debug.Log($"Вибрано кулю {index}");
        }
        else if (coins >= prices[index])
        {
            coins -= prices[index];
            PlayerPrefs.SetInt(CoinsKey, coins);
            PlayerPrefs.SetInt("BalloonBought_" + index, 1);
            PlayerPrefs.SetInt(SelectedKey, index);
            PlayerPrefs.Save();

            priceTexts[index].text = "SOLD";
            UpdateCoinsUI();

            Debug.Log($"Куплено кулю {index}");
        }
        else
        {
            Debug.Log("Недостатньо монет!");
        }
    }

    void UpdateCoinsUI()
    {
        coinsText.text = "BALANCE: " + coins;
    }
}
