using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
    static public int score = 0;

    void Awake() {
        // Если уже существуют рекорды в PlayerPrefs
        if (PlayerPrefs.HasKey("HighScore")) {
            score = PlayerPrefs.GetInt("HighScore");
        }
        // Сохранить рекорд в хранилище 
        PlayerPrefs.SetInt("HighScore",score);
    }

    void Update() {
        Text gt = this.GetComponent<Text>();
        gt.text = "High Score "+score;

        // Обновить рекорд
        if (score > PlayerPrefs.GetInt("HighScore")){
            PlayerPrefs.SetInt("HighScore",score);
        }
    }
}
