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
        
        public override void InstallBindings()
        {
            BindMoneyBag();
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
    }
}
