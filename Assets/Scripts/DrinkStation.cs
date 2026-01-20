using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;

abstract class DrinkStation : MonoBehaviour, IDropHandler
{
    public float fillTime = 5;
    protected int slotsAvailable = 3;
    protected GameObject[] currentDrinks = new GameObject[3];
    public Slider[] sliders = new Slider[3];
    public string flavour;
    public void OnDrop(PointerEventData eventData)
    {
        Cup cup = eventData.pointerDrag.GetComponent<Cup>();
        if (cup != null && slotsAvailable > 0 && (cup.currentDrink.flavour == ""|| (flavour == "blend" && !cup.currentDrink.blended)))
        {
            slotsAvailable--;
            currentDrinks[slotsAvailable] = eventData.pointerDrag;
            eventData.pointerDrag.transform.position = gameObject.transform.GetChild(slotsAvailable).transform.position;
            eventData.pointerDrag.GetComponent<Image>().raycastTarget = false;
            cup.processing = true;
            sliders[slotsAvailable].gameObject.SetActive(true);
            sliders[slotsAvailable].value = 0;
            StartCoroutine(ProcessCup(slotsAvailable));
        }
    }

    protected IEnumerator ProcessCup(int slot)
    {
        while(sliders[slot].value != 1)
        {
            sliders[slot].value += 0.01f;
            yield return new WaitForSeconds(fillTime / 100);
        }
        sliders[slot].gameObject.SetActive(false);
        currentDrinks[slot].GetComponent<Image>().raycastTarget = true;
        UpdateCup(slot);
        currentDrinks[slot].GetComponent<Cup>().processing = false;
        slotsAvailable++;
    }

    protected abstract void UpdateCup(int slot);
}
