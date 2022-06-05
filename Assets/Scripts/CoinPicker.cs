using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  

public class CoinPicker : MonoBehaviour
{
    [Header("Set in Inspector")]
    public GameObject basketPrefab;
    public int numBaskets = 3;
    public float basketBottomY = -14f; // По Y местоположение 
    public float basketSpacingY = 2f; // Дистанция между корзинками 
    public List<GameObject> basketList;

    void Start() 
    {
        // Создание корзинок
        basketList = new List<GameObject>();
        for (int i=0; i<numBaskets; i++) {
            GameObject tBasketGO = Instantiate<GameObject>(basketPrefab);
            Vector3 pos = Vector3.zero;
            pos.y = basketBottomY + (basketSpacingY * i);
            tBasketGO.transform.position = pos;
            basketList.Add(tBasketGO);
        }    
    }

    public void CoinDestroyed() {
        // Удаление всех монет
        GameObject[] tCoinArray = GameObject.FindGameObjectsWithTag("Coin");
        foreach (GameObject tGO in tCoinArray) {
            Destroy(tGO);
        }

        int basketIndex = basketList.Count-1;
        GameObject tBasketGO = basketList[basketIndex];
        basketList.RemoveAt(basketIndex);
        Destroy(tBasketGO);

        if(basketList.Count == 0) {
            SceneManager.LoadScene("Game");
        }
    }

    

}
