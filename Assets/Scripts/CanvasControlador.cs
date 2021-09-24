using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasControlador : MonoBehaviour
{

    private GameObject player;
    private GameObject respawn;

    private GameObject canvasMuerte;
    private GameObject crosshair;

    private void Awake()
    {
        canvasMuerte = GameObject.Find("MenuMuerte");
        player = GameObject.FindWithTag("Player");
        respawn = GameObject.Find("SpawnPoint");
        crosshair = GameObject.Find("CrossHair");
    }
    public void respawnPlayer()
    {
        player.transform.position = respawn.transform.position;
        if (canvasMuerte.activeInHierarchy)
        {
            canvasMuerte.SetActive(false);
        }
        if (!crosshair.activeInHierarchy)
        {
            crosshair.SetActive(true);
        }
        Cursor.lockState = CursorLockMode.Locked;
        player.GetComponent<Healt_and_Damage>().vida = 100;
    }
}
