using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class OptionUI : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerEnterHandler, IPointerExitHandler
{
    public Vector3 normalScale = Vector3.one;
    public Vector3 highlightedScale = Vector3.one;
    public Color normalColor;
    public Color highlightedColor;
    private Image image;
    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
        makeNormal();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerDown(PointerEventData pointerEventData) {
        DialogueUI.instance.selectOption(transform.GetSiblingIndex());
        makeNormal();
    }

    public void OnPointerUp(PointerEventData pointerEventData) {
        makeHighlighted();
    }

    public void OnPointerEnter(PointerEventData pointerEventData) {
        makeHighlighted();
    }

    public void OnPointerExit(PointerEventData pointerEventData) {
        makeNormal();
    }

    private void scale(Vector3 newScale) {
        transform.localScale = newScale;
    }

    private void makeNormal() {
        image.color = normalColor;
        scale(normalScale);
    }

    private void makeHighlighted() {
        image.color = highlightedColor;
        scale(highlightedScale);
    }
}
