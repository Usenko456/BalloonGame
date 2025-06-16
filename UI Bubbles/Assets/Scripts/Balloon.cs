using UnityEngine;

public class Balloon : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public int spriteIndex;

    private float speed = 2.5f;
    private const int baseScore = 5;

    void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }
    void OnMouseDown()
    {
        int scoreToAdd = CalculateBonusScore(spriteIndex);
        GameManager.Instance.AddScore(scoreToAdd);
        Destroy(gameObject);
    }
    public void SetData(Sprite sprite, int index)
    {
        spriteRenderer.sprite = sprite;
        spriteIndex = index;
    }

    int CalculateBonusScore(int index)
    {
        bool isPurchased = PlayerPrefs.GetInt("BalloonBought_" + index, 0) == 1;

        if (!isPurchased)
            return baseScore;

        int price = ShopManager.Instance.prices[index];
        float bonusMultiplier = 1 + (price / 100f); 

        return Mathf.RoundToInt(baseScore * bonusMultiplier);
    }
}
