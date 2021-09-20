using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevantarArma : MonoBehaviour
{

    public GameObject armaEnSuelo;
    public GameObject armaJugador;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "ArmaPortal"){
            armaEnSuelo.SetActive(false);
            armaJugador.SetActive(true);
        }
    }


}
