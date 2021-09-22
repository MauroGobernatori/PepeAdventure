using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasControlador : MonoBehaviour
{

    private GameObject player;
    private GameObject respawn;

    private GameObject canvasMuerte;

    private void Awake()
    {
        canvasMuerte = GameObject.Find("MenuMuerte");
        player = GameObject.FindWithTag("Player");
        respawn = GameObject.Find("SpawnPoint");
    }
    public void respawnPlayer()
    {
        player.transform.position = respawn.transform.position;
        if (canvasMuerte.activeInHierarchy)
        {
            canvasMuerte.SetActive(false);
        }
        Cursor.lockState = CursorLockMode.Locked;
    }
}
