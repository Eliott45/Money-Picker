using System;
using System.Collections.Generic;
using Models;
using Pooling_System;
using UnityEngine;
using Views;

namespace Controllers
{
    public class CoinBasketsController
    {
        private readonly CoinBasketsModel _coinBasketsModel;
        private readonly CoinBasketsView _basketPrefab;

        private readonly List<CoinBasketsView> _basketList = new ();
        
        public CoinBasketsController(CoinBasketsModel coinBasketsModel, CoinBasketsView basketPrefab)
        {
            _coinBasketsModel = coinBasketsModel ?? throw new NullReferenceException();
            _basketPrefab = basketPrefab ? basketPrefab : throw new NullReferenceException();
            
            InitBaskets();
        }

        private void InitBaskets()
        {
            for (var i = 0; i < _coinBasketsModel.MaxBaskets; i++) {
                var pos = Vector3.zero;
                pos.y = _coinBasketsModel.BasketBottomY + _coinBasketsModel.BasketSpacingY * i;
                var basket = Pool.Create(_basketPrefab);
                basket.gameObject.transform.position = pos; 
                basket.OnCollision += CheckCollision;
                _basketList.Add(basket);
            }
        }

        private static void CheckCollision(object sender, Collision coll)
        {
            if (coll.gameObject.CompareTag("Coin"))
            {
                Pool.Return(coll.gameObject);
            }
        }
    }
}