using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public Image image;
    public GameObject emptySprite;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI priceText;
    private Item item;

    public void SetItem(Item setItem)
    {
        item = setItem;
        if(item != null)
        {
            image.sprite = item.sprite;
            nameText.text = item.name;
            priceText.text = "" + item.price;
        }
        emptySprite.SetActive(item == null);
    }
}
