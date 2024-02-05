using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishVariaton : SecondFloorGoods // INHERITANCE
{
    public override void HealPlayer() // POLYMORPHISM
    {
        PlayerHealth.health += 2;
    }
}
