using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private UI_Inventory uiInventory = null;
    [SerializeField] private Transform respawn = null;

    private Collectable collectable;
    //private Inventory inventory;
    private Inventario inventory;

    private Transform UI_Inventory;
    private bool showInventory = false;
    private GameObject canvas;

    private void Awake()
    {
        canvas = GameObject.Find("Canvas");
        if (canvas.activeInHierarchy)
        {
            // Si el canvas está activo, desactivarlo
            canvas.SetActive(false);
        }
        inventory = GameObject.FindGameObjectWithTag("Inventario").GetComponent<Inventario>();
        uiInventory.setInventory(inventory);
        

        //inventory = new Inventory();
        //uiInventory.setInventory(inventory);

        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            showInventory = !showInventory;
            if (showInventory)
            {
                // Mostrar el inventario
                canvas.SetActive(true);
            }
            else
            {
                // Esconder el inventario
                canvas.SetActive(false);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Collectable")
        {
            collectable = collision.gameObject.GetComponent<Collectable>();
            switch (collectable.itemType)
            {
                case Item.ItemType.book:
                    inventory.inventory.addItem(new Item { itemType = Item.ItemType.book });
                    inventory.itemList.Add(new Item { itemType = Item.ItemType.book });
                    //inventory.addItem(new Item { itemType = Item.ItemType.book });
                    break;
                case Item.ItemType.bronce_ring:
                    
                    //inventory.addItem(new Item { itemType = Item.ItemType.bronce_ring });
                    break;
                case Item.ItemType.clover:
                    
                    //inventory.addItem(new Item { itemType = Item.ItemType.clover });
                    break;
                case Item.ItemType.feather:
                    
                    //inventory.addItem(new Item { itemType = Item.ItemType.feather });
                    break;
                case Item.ItemType.scroll:
                    
                    //inventory.addItem(new Item { itemType = Item.ItemType.scroll });
                    break;
                default:
                    break;
            }
            uiInventory.setInventory(inventory);
            Destroy(collision.gameObject);
        }

        if(collision.gameObject.tag == "Lava")
        {
            transform.position = respawn.position;
        }
    }
}
