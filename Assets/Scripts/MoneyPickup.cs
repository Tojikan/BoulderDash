using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyPickup : Collectible
{
    protected override void PickUpItem()
    {
        GameData.PickUpMoney();
        gameManager.SetMoneyCounter();
    }

    protected override void PickUpAnimation()
    {
        Debug.Log("Picked up a money!");
    }

}
