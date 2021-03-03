using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class AppleTree : MonoBehaviour
{
    // Вводные данные
    [Header("Set In Inspector")]
    public GameObject applePrefab; 
    public float speed = 1f; 
    public float changeDistance = 10f; // Растояние на котором должно изменяться направление движения мешка
    public float chanceToChangeDirections = 0.1f; // Вероятность изменения направления движения
    public float secondsBetweenAppleDrops = 1f; // Частота спавна монеток
    public Text scoreGT;
    
    void Start () {
        // Сбрасывать монеты раз в секунду
        Invoke("DropApple",2f); // Вызвать функцию через 2 секунды
    }

    void DropApple() { // Спавн монт
        GameObject apple = Instantiate<GameObject>(applePrefab); 
        apple.transform.position = transform.position;
        Invoke("DropApple", secondsBetweenAppleDrops);
    }

    void Update () {
        // Простое перемещение мешка
        Vector3 pos = transform.position; // Текущая позиция мешка
        pos.x += speed * Time.deltaTime; // Перемещение по оси X
        transform.position = pos; // Меняет исходную позицию на позицию из переменной "pos"
        // Изменение направления
        if ( pos.x < -changeDistance) { // Если Х достигнет предела
            speed = Mathf.Abs(speed); // Начать движения вправо (Matf.Abs - возращает абсолютное положительное значение)
        } else if ( pos.x > changeDistance) {
            speed = -Mathf.Abs(speed);
        } 

        int score = int.Parse(scoreGT.text);
        
        // Сложность
        if (score >= 200 && score < 500) {
            if (speed > 0) {
                speed = 25f;
            } else {
                speed = -25f;
            }
            secondsBetweenAppleDrops = 0.9f;
        } else if (score >= 500 && score < 1000) {
            if (speed > 0) {
                speed = 40f;
            } else {
                speed = -40f;
            }
            secondsBetweenAppleDrops = 0.7f;           
        } else if (score >= 1000 && score < 2000) {
            if (speed > 0) {
                speed = 60f;
            } else {
                speed = -60f;
            }
            secondsBetweenAppleDrops = 0.45f;           
        }  else if (score >= 2000 && score < 3000) {
            if (speed > 0) {
                speed = 70f;
            } else {
                speed = -70f;
            }
            secondsBetweenAppleDrops = 0.40f;           
        } else if (score >= 3000 && score < 4200) {
            if (speed > 0) {
                speed = 80f;
            } else {
                speed = -80f;
            }
            secondsBetweenAppleDrops = 0.35f;           
        } else if (score >= 4200 && score < 6000) {
            if (speed > 0) {
                speed = 85f;
            } else {
                speed = -85f;
            }
            secondsBetweenAppleDrops = 0.30f;           
        } else if (score >= 6000 && score < 8000) {
            if (speed > 0) {
                speed = 90f;
            } else {
                speed = -90f;
            }
            secondsBetweenAppleDrops = 0.25f;           
        } else if (score >= 8000 && score < 10000) {
            if (speed > 0) {
                speed = 95f;
            } else {
                speed = -95f;
            }
            secondsBetweenAppleDrops = 0.20f;           
        } 





    

        /*
            Почему не @transform.position.x += speed * Time.deltaTime;@ ?
            transform.position - можно лишь читать
        */
    }

    void FixedUpdate() {
        // Случайная смена направления привзана ко времени (50fps/1s)
        if ( Random.value < chanceToChangeDirections) { // от 0 до 1 рандомная цифра, если меньше шанса изменить направление, значит меняет направление
            speed *= -1; // Напрваление в другую сторону
        }
    }
}
