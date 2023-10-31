using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentItem : Item
{
   public int additionalAtk;
   bool isEquip = false;
   public override void Use(Player player)
   {
        if(isEquip == false)
        {
            if(player.weapon != null)
            {
                player.weapon.Use(player);
            }
            player.weapon = this;
        }
        else
        {
            player.weapon = null;
        }
        isEquip = !isEquip;     
   }
}
