using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  

public class Menu : MonoBehaviour
{
    public void Update() {
        if (Input.GetKey("escape"))  // если нажата клавиша Esc (Escape)
        {
           Application.Quit();    // закрыть приложение
        }
    }
    
    public void ChangeScene() {
        SceneManager.LoadScene("Game");
    }
}
