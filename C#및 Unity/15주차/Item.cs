using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    public Sprite sprite;
    public string name;
    public int price;

    public virtual void Use(Player player)
    {
        Debug.Log("아이템 사용");
    }
}
