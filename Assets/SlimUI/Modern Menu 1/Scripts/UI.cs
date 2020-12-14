using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour {


    public void Play()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }


    public void Quitgame ()

    {

        Application.Quit();
    }

    public void Restartgame()


    {

        SceneManager.LoadScene("Level");

    }

}