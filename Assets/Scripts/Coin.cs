using Pooling_System;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private float _maxBottomYPosition = -20f;

    private void Update()
    {
        CheckPositionAdmissibility();
    }

    private void CheckPositionAdmissibility()
    {
        if (!(transform.position.y < _maxBottomYPosition)) return;
        Pool.Return(gameObject);

        CoinPicker apScript = Camera.main.GetComponent<CoinPicker>(); // Получить ссылку на компонент 
        apScript.CoinDestroyed(); // Вызвать метод
    }
}
