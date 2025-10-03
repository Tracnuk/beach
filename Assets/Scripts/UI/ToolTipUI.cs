using UnityEngine;
using TMPro;

public class TooltipUI : MonoBehaviour
{
    public static TooltipUI Instance;

    [Header("UI References")]
    public GameObject panel;         // Панель подсказки
    public TextMeshProUGUI text;     // Текст описания

    private void Awake()
    {
        Instance = this;
        Hide();
    }

    public void Show(string message)
    {
        panel.SetActive(true);
        text.text = message;
    }

    public void Hide()
    {
        panel.SetActive(false);
    }
}
