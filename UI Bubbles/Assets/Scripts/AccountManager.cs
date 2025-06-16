using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AccountManager : MonoBehaviour
{
    [Header("UI Elements")]
    public TMP_InputField nameInput;
    public TMP_Text nicknameText;
    public Image avatarImage;

    private const string PlayerNameKey = "PlayerName";
    private const string AvatarNameKey = "AvatarName"; 

    void Start()
    {
        // Завантаження імені
        string savedName = PlayerPrefs.GetString(PlayerNameKey, "Player");
        nicknameText.text = savedName;
        nameInput.text = savedName;

        // Завантаження аватарки
        string avatarSpriteName = PlayerPrefs.GetString(AvatarNameKey, "");
        if (!string.IsNullOrEmpty(avatarSpriteName))
        {
            Sprite loaded = Resources.Load<Sprite>("Avatars/" + avatarSpriteName);
            if (loaded != null)
                avatarImage.sprite = loaded;
        }
    }

    public void SaveName()
    {
        string newName = nameInput.text;
        nicknameText.text = newName;
        PlayerPrefs.SetString(PlayerNameKey, newName);
        string currentSpriteName = avatarImage.sprite.name;
        PlayerPrefs.SetString(AvatarNameKey, currentSpriteName);

        PlayerPrefs.Save();
        nameInput.text = "";
    }

    public void SetAvatar(Sprite newAvatar)
    {
        avatarImage.sprite = newAvatar;
    }
}
