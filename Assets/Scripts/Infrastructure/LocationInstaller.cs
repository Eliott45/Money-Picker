using Controllers;
using Models;
using UnityEngine;
using Views;
using Zenject;

namespace Infrastructure
{
    public class LocationInstaller : MonoInstaller
    {
        [Header("Money bag data:")]
        [SerializeField] private MoneyBagView _moneyBagViewPrefab;
        [SerializeField] private float _moneyBagSpeed;
        [SerializeField] private float _moneyBagSpawnCoinSpeed;
        [SerializeField] private Coin _coinPrefab;

        [Header("Coin picker data:")] 
        [SerializeField] private CoinBasketsView _coinBasketsView;
        [SerializeField] private int _maxBaskets = 3;
        [SerializeField] private float _basketBottomY = -14;
        [SerializeField] private float _basketSpacingY = 2;

        public override void InstallBindings()
        {
            BindMoneyBag();
            BindCoinBaskets();
        }

        private void BindMoneyBag()
        {
            /*
            var moneyBagView = Container
                .InstantiatePrefabForComponent<MoneyBagView>(_moneyBagViewPrefab);
            */
            
            var moneyBagModel = new MoneyBagModel(_moneyBagSpeed, _moneyBagSpawnCoinSpeed);
            var moneyBagController = new MoneyBagController(moneyBagModel, _coinPrefab, _moneyBagViewPrefab);
            
            /*
            Container
                .Bind<MoneyBagView>()
                .FromInstance(moneyBagView)
                .AsSingle()
                .NonLazy();
            */
            //var moneyBagModel = new MoneyBagModel(_moneyBagSpeed);
            //var moneyBagController = new MoneyBagController(moneyBagModel, moneyBagView);
        }

        private void BindCoinBaskets()
        {
            var coinBasketsModel = new CoinBasketsModel(_basketBottomY, _basketSpacingY, _maxBaskets);
            var moneyBagController = new CoinBasketsController(coinBasketsModel, _coinBasketsView);
        }
    }
}
