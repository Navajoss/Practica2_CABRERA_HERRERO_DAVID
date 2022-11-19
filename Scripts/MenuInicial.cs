using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuInicial : MonoBehaviour
{
    //we put the use of buttons
    public void Play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Debug.Log("Jugar...");
    }

    public void Exit()
    {
        Debug.Log("Salir...");
        Application.Quit();
    }
}
