using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject menu;
    float time = 0.01f;
    bool select = false;
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void Update()
    {
        time -= Time.deltaTime;
        if (Input.GetKeyDown("escape") && select == false && time <= 0)
        {
            menu.SetActive(true);
            select = true;
            time = 0.01f;
        }
        if (Input.GetKeyDown("escape") && select == true && time <= 0)
        {
            menu.SetActive(false);
            select = false;
            time = 0.01f;
        }

    }
    public void ESC()
    {
        time -= Time.deltaTime;
        if (select == false && time <= 0)
        {
            menu.SetActive(true);
            select = true;
            time = 0.01f;
        }
        if (select == true && time <= 0)
        {
            menu.SetActive(false);
            select = false;
            time = 0.01f;
        }
    }
}
