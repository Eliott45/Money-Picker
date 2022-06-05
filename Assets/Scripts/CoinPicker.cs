using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  

public class CoinPicker : MonoBehaviour
{
    [Header("Set in Inspector")]
    [SerializeField] private GameObject _basketPrefab;
    [SerializeField] private int _numBaskets = 3;
    [SerializeField] private float _basketBottomY = -14f; // По Y местоположение 
    [SerializeField] private float _basketSpacingY = 2f; // Дистанция между корзинками 
    [SerializeField] private List<GameObject> basketList;

    private void Start() 
    {
        basketList = new List<GameObject>();
        for (var i = 0; i < _numBaskets; i++) {
            var tBasketGO = Instantiate(_basketPrefab);
            var pos = Vector3.zero;
            pos.y = _basketBottomY + _basketSpacingY * i;
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
