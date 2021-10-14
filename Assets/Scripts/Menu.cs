using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{   
    public string cena;
    public GameObject optionsPanel;
    // public string stopGaming;

    public void StartGame()
    {
        SceneManager.LoadScene(cena);
    }

    public void QuitGame()
    {
        // Editor Unity
            UnityEditor.EditorApplication.isPlaying = false;

        // Jogo Compilado
            //Application.Quit();
    }

    public void ShowOptions()
    {
        optionsPanel.SetActive(true);
    }

    public void MainMenu()
    {
        optionsPanel.SetActive(false);
    }

    /*
    public void StopPlaying()
    {
        if(Input.GetButtonDown("Cancel"))
        {
            SceneManager.LoadScene(stopGaming);
        }
    }
    */
}
