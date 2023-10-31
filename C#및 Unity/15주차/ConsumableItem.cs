using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsumableItem : Item
{
    public int value;
    public override void Use(Player player)
    {
        player.hp += 10;
    }
}
