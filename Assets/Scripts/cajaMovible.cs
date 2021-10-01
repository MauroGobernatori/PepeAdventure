using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cajaMovible : MonoBehaviour
{
    private GameObject puntoAgarre;
    private GameObject player;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        puntoAgarre = GameObject.Find("puntoAgarre");
    }
    public void grabbed()
    {
        GetComponent<Rigidbody>().useGravity = false;
        GetComponent<Rigidbody>().isKinematic = true;
        transform.position = puntoAgarre.transform.position;
        transform.rotation = puntoAgarre.transform.rotation;
        transform.parent = puntoAgarre.transform;
    }

    public void released()
    {
        GetComponent<Rigidbody>().useGravity = true;
        GetComponent<Rigidbody>().isKinematic = false;
        transform.parent = null;
        transform.position = puntoAgarre.transform.position;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name != "Piso")
        {
            player.GetComponent<Player>().released();
            Debug.Log("Choque");
        }
    }
}
