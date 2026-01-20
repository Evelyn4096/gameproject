using UnityEngine;
using UnityEngine.EventSystems;

public class Trash : MonoBehaviour, IDropHandler
{
    public GameObject cupPrefab;
    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag.GetComponent<Cup>() != null)
        {
            Instantiate(cupPrefab, transform.parent);
            Destroy(eventData.pointerDrag);
        }
    }
}
