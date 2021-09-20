using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventario : MonoBehaviour
{

    public Inventory inventory;

    public List<Item> itemList;

    private void Awake()
    {
        inventory = new Inventory();
        itemList = new List<Item>();

        DontDestroyOnLoad(this.gameObject);
    }

    public List<Item> getItemList()
    {
        return itemList;
    }

}
