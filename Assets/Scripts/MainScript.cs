using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainScript : MonoBehaviour
{
    [SerializeField] private Button _lightingButton;
    [SerializeField] private Button _lifeButton;
    [SerializeField] private Button _starButton;
    [SerializeField] private Button _moneyButton;
    [SerializeField] private ShopPopup _shopPopup;

    private Dictionary<Button, TypeShopValue> buttonToShopValue;

    private void Start() {
        buttonToShopValue = new Dictionary<Button, TypeShopValue> {
            { _lightingButton, TypeShopValue.Lighting },
            { _lifeButton, TypeShopValue.Life },
            { _starButton, TypeShopValue.Star },
            { _moneyButton, TypeShopValue.Money }
        };

        foreach (var entry in buttonToShopValue) {
            entry.Key.onClick.AddListener(() => _shopPopup.ShowPopup(entry.Value));
        }
    }
}