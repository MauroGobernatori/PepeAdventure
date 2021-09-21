using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private UI_Inventory uiInventory = null;

    private Collectable collectable;
    private Inventario inventory;

    private Transform UI_Inventory;
    private bool showInventory = false;
    private GameObject canvas;

    private bool shiftInput = false;

    private GameObject camera;

    private void Awake()
    {
        canvas = GameObject.Find("Canvas");
        if (canvas.activeInHierarchy)
        {
            // Si el canvas está activo, desactivarlo
            canvas.SetActive(false);
        }
        // Obtiene el inventario, vacío en la primer escena, con objetos las siguientes escenas
        inventory = GameObject.FindGameObjectWithTag("Inventario").GetComponent<Inventario>();
        uiInventory.setInventory(inventory);

        camera = GameObject.FindWithTag("PlayerCamera");
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

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            //shiftInput = true;
        }
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            int x = Screen.width / 2;
            int y = Screen.height / 2;

            Ray ray = camera.GetComponent<Camera>().ScreenPointToRay(new Vector3(x, y));
            RaycastHit hit;

            Debug.DrawRay(ray.origin, ray.direction * 10, Color.yellow);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.tag == "MovableBox")
                {
                    Debug.Log("Se puede mover");
                }
            }
        }

        if (shiftInput)
        {
            int x = Screen.width / 2;
            int y = Screen.height / 2;

            Ray ray = camera.GetComponent<Camera>().ScreenPointToRay(new Vector3(x,y));
            RaycastHit hit;

            Debug.DrawRay(ray.origin, ray.direction * 10, Color.yellow);

            if(Physics.Raycast(ray, out hit))
            {
                if(hit.transform.tag == "MovableBox")
                {
                    Debug.Log("Se puede mover");
                }
            }
            shiftInput = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Collectable")
        {
            collectable = collision.gameObject.GetComponent<Collectable>();
            Destroy(collision.gameObject);
            switch (collectable.itemType)
            {
                case Item.ItemType.book:
                    inventory.itemList.Add(new Item { itemType = Item.ItemType.book });
                    break;
                case Item.ItemType.bronce_ring:
                    inventory.itemList.Add(new Item { itemType = Item.ItemType.bronce_ring });
                    break;
                case Item.ItemType.clover:
                    inventory.itemList.Add(new Item { itemType = Item.ItemType.clover });
                    break;
                case Item.ItemType.feather:
                    inventory.itemList.Add(new Item { itemType = Item.ItemType.feather });
                    break;
                case Item.ItemType.scroll:
                    inventory.itemList.Add(new Item { itemType = Item.ItemType.scroll });
                    break;
                default:
                    break;
            }
            uiInventory.setInventory(inventory);
        }
    }
}
