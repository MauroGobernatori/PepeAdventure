using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    Este Script le da un valor de vida al personaje, un estado de invencibilidad y una funcion que le resta la vida cuando toca la lava, dandole invencibilidad 
cada 1 segundo para evitar que muera demasiado rapido (ya que sin la corutina de invulnerabilidad esta función se ejecutara por cada frame que el jugador pase en la lava).
*/
public class Healt_and_Damage : MonoBehaviour
{
    public int vida = 100;
    public bool invencible = false;

    public GameObject jugador;
    public float tiempo_invencible = 1f;
    public float tiempo_frenado = 0.2f;

    // Canvas de muerte
    private bool showMuerte = false;
    private GameObject canvasMuerte;

    //Canvas Crosshair
    private GameObject crosshair;

    private void Awake()
    {
        crosshair = GameObject.Find("CrossHair");
        canvasMuerte = GameObject.Find("MenuMuerte");
        if (canvasMuerte.activeInHierarchy)
        {
            // Si la muerte está activo en canvas, desactivarlo
            canvasMuerte.SetActive(false);
        }
    }

    //Crea una función que si la vida es mayor a 0 y el usuario no se encuentra en un estado de invencibilidad dicha función comenzara a restarle 10 de vida cada 1 seg.
    public void RestarVida(int cantidad) {
        if (!invencible && vida > 0){
            vida -= cantidad;
            StartCoroutine(Invulnerabilidad());
            StartCoroutine(FrenarVelocidad());
            
            if(vida == 0) {
                GameOver();
            }
        }
    }

    void GameOver() {
        //Poner aqui script para menu de muerte.
        showMuerte = !showMuerte;
        if (showMuerte)
        {
            crosshair.SetActive(false);
            Cursor.lockState = CursorLockMode.None;

            canvasMuerte.SetActive(true);
            showMuerte = !showMuerte;
        }
    }

    //Crea una especie de tiempo de invencibilidad para evitar que se le reste vida de la forma default (con cada frame) ya que es demasiado rapida.
    IEnumerator Invulnerabilidad() {
        invencible = true;
        yield return new WaitForSeconds(tiempo_invencible);
        invencible = false;
    }

    //Guarda en la variable velocidadActual la velocidad con la que el jugador toca la lava.
    IEnumerator FrenarVelocidad() {
        var velocidadActual = GetComponent<FirstPersonMovement>().speed;
        GetComponent<FirstPersonMovement>().speed = 0;
        yield return new WaitForSeconds(tiempo_frenado);
        GetComponent<FirstPersonMovement>().speed = velocidadActual;
    }
}
