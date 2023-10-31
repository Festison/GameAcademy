using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int hp;
    public int atk;

    public GameObject invenObj;
    public List<Item> inventory = new List<Item>();
    public EquipmentItem weapon = null;
    private void OnTriggerEnter(Collider other)
    {

        if (other.TryGetComponent(out Item item))
        {
            item.gameObject.SetActive(false);
            item.transform.SetParent(invenObj.transform);
            inventory.Add(item);
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            foreach(Item item in inventory)
            {
                item.Use(this);
            }
        }
    }
}
