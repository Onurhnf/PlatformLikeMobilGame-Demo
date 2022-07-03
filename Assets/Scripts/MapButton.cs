using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapButton : MonoBehaviour
{

    int currentHealth=3;
    public void mapButton()
    {
        SceneManager.LoadScene(0);
    }



    public void GameEnd(int gameEndHealth)
    {
        currentHealth = gameEndHealth;
        //PlayerPrefs.DeleteAll();
        if (currentHealth>PlayerPrefs.GetInt("Lv"+SceneManager.GetActiveScene().buildIndex))
        {
            PlayerPrefs.SetInt("Lv" + SceneManager.GetActiveScene().buildIndex, currentHealth);
        }

        mapButton();

    }

    public void deleteButton()
    {
        PlayerPrefs.DeleteAll();
    }


}
