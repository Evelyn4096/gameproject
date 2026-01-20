using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;

class BlendStation : DrinkStation
{
    protected override void UpdateCup(int slot)
    {
        currentDrinks[slot].GetComponent<Cup>().currentDrink.blended = true;
    }
}
