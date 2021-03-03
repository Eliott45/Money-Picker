using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public static float bottomY = -20f; // Предел падания монеты

    void Update()
    {
        if (transform.position.y < bottomY) { // Если монета достигнет -20f
            Destroy(this.gameObject);

            CoinPicker apScript = Camera.main.GetComponent<CoinPicker>(); // Получить ссылку на компонент 
            apScript.CoinDestroyed(); // Вызвать метод
        }    
    }
}
