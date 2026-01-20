using System;
using UnityEngine;
public class Order : MonoBehaviour
{
    public int ice, sugar, tapioka, coffeeJelly, cookieCrumble;
    public bool blended;
    public string flavour;

    public bool MatchesOrder(Order other)
    {
        if(ice != other.ice || sugar != other.sugar || tapioka != other.tapioka || coffeeJelly != other.coffeeJelly || cookieCrumble != other.cookieCrumble || blended != other.blended || flavour != other.flavour)
            return false;
        return true;
    }
}
