using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OrderChecker : MonoBehaviour, IDropHandler
{
    public GameObject cupPrefab;
    private int strikes = 0;
    public List<Order> orders = new();
    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag.GetComponent<Cup>() != null)
        {
            Instantiate(cupPrefab, transform.parent);
            foreach(Order order in orders)
            {
                if(order.MatchesOrder(eventData.pointerDrag.GetComponent<Cup>().currentDrink))
                {
                    Debug.Log("Correct Drink!!");
                    orders.Remove(order);
                    Destroy(eventData.pointerDrag);
                    return;
                }
            }
            Destroy(eventData.pointerDrag);
            strikes++;
            Debug.Log("Wrong!! You have " + strikes + " strikes");
        }
    }
}
