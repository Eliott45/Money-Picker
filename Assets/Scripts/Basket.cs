using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Подключение библиотеки для работы с UI

public class Basket : MonoBehaviour
{
    [Header("Set Dynamically")]
    public Text scoreGT;

    void Start() {
        GameObject scoreGO = GameObject.Find("ScoreCounter");
        scoreGT = scoreGO.GetComponent<Text>();
        scoreGT.text = "0";
    }

    void Update()
    {
        // Получить текущие координаты мыши на экране
        Vector3 mousePos2D = Input.mousePosition;
        
        // Координата Z камеры определяет, как далеко в трехмерном пространстве находится указатель мыши
        //! mousePos2D.z = -Camera.main.transform.position.z; 

        // Преобразовать точку на двумерной плоскости энрана в трехмерные координаты игры
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);

        // Переместить корзину вдоль оси Х в координату Х указателя мыши
        Vector3 pos = this.transform.position;
        pos.x = mousePos3D.x;
        this.transform.position = pos;

    }

    void OnCollisionEnter(Collision coll) { // Если корзина столкнется с объектом
        // Отыскать монету, попавшую в эту корзину
        GameObject collidedWith = coll.gameObject;
        if (collidedWith.tag == "Coin") {
            Destroy (collidedWith);
            int score = int.Parse(scoreGT.text);
            score+=100;
            scoreGT.text = score.ToString();
            
            // Рекорд
            if (score > HighScore.score) {
                HighScore.score = score;
            }
        }
    }
}
