using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public enum TypeShopValue {
    Star,
    Money,
    Life,
    Lighting
}
public class ShopPopupPositions : MonoBehaviour {
    [SerializeField] private Sprite _emptySlot;
    [SerializeField] private Sprite _fullSlot;
    [SerializeField] private Sprite _starIcon;
    [SerializeField] private Sprite _lightingIcon;
    [SerializeField] private Sprite _moneyIcon;
    [SerializeField] private Sprite _liveIcon;
    [SerializeField] private Image _iconContainer;
    [SerializeField] private TextMeshProUGUI _title;
    [SerializeField] private TextMeshProUGUI _counter;
    [SerializeField] private TextMeshProUGUI _counterTextFieldButton;

    public void SetIconAndText(TypeShopValue typeShopValue) {
        switch (typeShopValue) {
            case TypeShopValue.Star:
                _iconContainer.sprite = _starIcon;
                _title.text = "Star Power";
                break;

            case TypeShopValue.Money:
                _iconContainer.sprite = _moneyIcon;
                _title.text = "Money Power";
                break;

            case TypeShopValue.Life:
                _iconContainer.sprite = _liveIcon;
                _title.text = "Life Power";
                break;

            case TypeShopValue.Lighting:
                _iconContainer.sprite = _lightingIcon;
                _title.text = "Lighting Power";
                break;
        }
    }
    
    public void GenerateValueShopPositions(TypeShopValue typeShopValue) {
        SetIconAndText(typeShopValue);
        _counterTextFieldButton.text = (Random.Range(0.99f, 15.01f)).ToString("F2")+"$";
    }
}
