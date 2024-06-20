using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using Button = UnityEngine.UI.Button;

public class ShopPopup : MonoBehaviour {
    [SerializeField] private CanvasGroup _canvasGroup;
    [SerializeField] private RectTransform _rect;
    [SerializeField] private Button _btnClose;
    [SerializeField] private ShopPopupPositions _shopPopupPositionPrefab;
    [SerializeField] private RectTransform _scrollViewContainer;
    [SerializeField] private ScrollRect _scrollRect;
    private ShopPopupPositions[] _shopPopupPositionsArray;
    
    private void Start() {
        _btnClose.onClick.AddListener(CloseAndClearPopup);
        _rect.localScale = new Vector3(0.5f, 0.5f, 1f);
        _canvasGroup.interactable = false;
        _canvasGroup.blocksRaycasts = false;
        _canvasGroup.alpha = 0;
    }
    
    public void ShowPopup(TypeShopValue typeShopValue) {
        _rect.DOScale(1, 0.7f).SetEase(Ease.OutBack);
        _canvasGroup.interactable = true;
        _canvasGroup.blocksRaycasts = true;
        _canvasGroup.DOFade(1, 0.5f);
        int randomCount = Random.Range(1, 25);
        CreateAndSetupShopPopupPositions(randomCount, typeShopValue);
    }

    private void CreateAndSetupShopPopupPositions(int count, TypeShopValue typeShopValue)
    {
        _shopPopupPositionsArray = new ShopPopupPositions[count];
        for (int i = 0; i < count; i++) 
        {
            ShopPopupPositions shopPopupPosition = Instantiate(_shopPopupPositionPrefab);
            shopPopupPosition.transform.SetParent(_scrollViewContainer, false); 
            _shopPopupPositionsArray[i] = shopPopupPosition;
            shopPopupPosition.GenerateValueShopPositions(typeShopValue);
        }
        if (_scrollViewContainer.childCount < 5)
        {
            _scrollRect.vertical = false;
        }
        else
        {
            _scrollRect.vertical = true;
        }
    }
    
    private void CloseAndClearPopup() {
        ClearChildGameObjectsOf(_scrollViewContainer);
        _canvasGroup.interactable = false;
        _canvasGroup.blocksRaycasts = false;
        _canvasGroup.alpha = 0;
        _rect.DOScale(0.5f, 0.2f).SetEase(Ease.InBack);
    }
    
    private void ClearChildGameObjectsOf(Component parent) {
        foreach (Transform child in _scrollViewContainer) 
        {
            Destroy(child.gameObject);
        }
    }
}