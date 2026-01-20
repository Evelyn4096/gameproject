using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Cup : MonoBehaviour, IDropHandler, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public Order currentDrink;
    public bool processing;

    void Start()
    {
        currentDrink = gameObject.GetComponent<Order>();
    }
    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag.GetComponent<IngredientSource>() != null && eventData.pointerDrag.GetComponent<IngredientSource>().spawned != null)
        {
            eventData.pointerDrag.GetComponent<IngredientSource>().spawned.transform.SetParent(gameObject.transform);
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = new Vector3(Mouse.current.position.value.x, Mouse.current.position.value.y, 0);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        gameObject.GetComponent<Image>().raycastTarget = false;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if(!processing)
            gameObject.GetComponent<Image>().raycastTarget = true;
    }
}
