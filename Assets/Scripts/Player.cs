using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private UI_Inventory uiInventory = null;
    [SerializeField] private float grabbingDistance;

    private Collectable collectable;
    private Inventario inventory;
    private Transform UI_Inventory;

    // Canvas de inventario
    private bool showInventory = false;
    private GameObject canvasInventory;

    // Canvas de muerte
    private bool showMuerte = false;
    private GameObject canvasMuerte;

    //Canvas Crosshair
    private GameObject crosshair;

    private GameObject camera;

    private bool grabInput = false;
    private bool grabbingInput = false;
    private bool ungrabInput = false;
    private GameObject grabbing;
    private GameObject guide;

    private void Awake()
    {
        guide = GameObject.Find("puntoAgarre");
        grabbing = GameObject.Find("Grabbing");
        crosshair = GameObject.Find("CrossHair");
        canvasMuerte = GameObject.Find("MenuMuerte");
        /*
        if (canvasMuerte.activeInHierarchy)
        {
            // Si la muerte está activo en canvas, desactivarlo
            canvasMuerte.SetActive(false);
        }*/
        canvasInventory = GameObject.Find("UI_Inventory");
        if (canvasInventory.activeInHierarchy)
        {
            // Si el inventario está activo en canvas, desactivarlo
            canvasInventory.SetActive(false);
        }
        // Obtiene el inventario, vacío en la primer escena, con objetos las siguientes escenas
        inventory = GameObject.FindGameObjectWithTag("Inventario").GetComponent<Inventario>();
        uiInventory.setInventory(inventory);

        // Obtener la cámara para ver donde apunto
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
                canvasInventory.SetActive(true);
            }
            else
            {
                // Esconder el inventario
                canvasInventory.SetActive(false);
            }
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (!grabbingInput)
            {
                grabInput = true;
            }
            else
            {
                ungrabInput = true;
            }
        }
    }

    private void FixedUpdate()
    {
        if (grabInput)
        {
            int x = Screen.width / 2;
            int y = Screen.height / 2;

            Ray ray = camera.GetComponent<Camera>().ScreenPointToRay(new Vector3(x,y));
            RaycastHit hit;

            Debug.DrawRay(ray.origin, ray.direction * 10, Color.yellow);
            if(Physics.Raycast(ray, out hit))
            {
                if(hit.transform.gameObject.GetComponent<cajaMovible>())
                {
                    if (hit.distance < grabbingDistance)
                    {
                        grabInput = false;
                        guide.transform.position = new Vector3(hit.transform.position.x, hit.transform.position.y + 1, hit.transform.position.z);
                        grabbing = hit.transform.gameObject;
                        grabbing.GetComponent<cajaMovible>().grabed();
                        grabbingInput = true;
                    }
                    else
                    {
                        grabInput = false;
                    }
                }
                else
                {
                    grabInput = false;
                }
            }
        }

        if (ungrabInput)
        {
            grabbingInput = false;
            grabbing.GetComponent<cajaMovible>().ungrabbed();
            grabbing = null;
            ungrabInput = false;
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
