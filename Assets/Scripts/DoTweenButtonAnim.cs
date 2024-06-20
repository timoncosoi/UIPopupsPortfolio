using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

public class DoTweenButtonAnim : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler {

    public float hoverScale = 1.2f;     // Scale when the mouse hovers over the button
    public float clickScale = 0.9f;     // Scale when the button is clicked
    public float animationDuration = 0.5f; // Duration of the scaling animation

    private Vector3 originalScale;

    void Start() {
        // Store the original scale of the button
        originalScale = transform.localScale;
    }

    // When the pointer enters the button area
    public void OnPointerEnter(PointerEventData eventData) {
        transform.DOScale(originalScale * hoverScale, animationDuration);
    }

    // When the pointer exits the button area
    public void OnPointerExit(PointerEventData eventData) {
        transform.DOScale(originalScale, animationDuration);
    }

    // When the button is clicked
    public void OnPointerClick(PointerEventData eventData) {
        transform.DOScale(originalScale * clickScale, animationDuration / 2)
            .OnComplete(() => transform.DOScale(originalScale * hoverScale, animationDuration / 2));
    }   
}
