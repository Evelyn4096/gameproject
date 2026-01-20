using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;

class FillStation : DrinkStation
{
    protected override void UpdateCup(int slot)
    {
        currentDrinks[slot].GetComponent<Cup>().currentDrink.flavour = flavour;
    }
}
