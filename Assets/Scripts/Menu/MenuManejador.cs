using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManejador : MonoBehaviour
{

    public void loadScene(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void quit()
    {
        Application.Quit();
        Debug.Log("Salir del juego");
    }

}
