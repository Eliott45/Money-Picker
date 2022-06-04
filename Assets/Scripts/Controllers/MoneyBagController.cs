using System;
using System.Threading.Tasks;
using Models;
using Pooling_System;
using Views;

namespace Controllers
{
    public class MoneyBagController
    {
        private readonly MoneyBagModel _model;
        private readonly MoneyBagView _view;
        private readonly Coin _coin;
        
        public MoneyBagController(
            MoneyBagModel model, 
            Coin coin,
            MoneyBagView view)
        {
            _model = model ?? throw new NullReferenceException();
            _view = view ? view : throw new NullReferenceException();
            _coin = coin ? coin : throw new NullReferenceException();

            SubscribeToView();
            SubscribeToModel();
            TransferDataModelToView();
            SpawnCoin();
        }

        private void SubscribeToView()
        {
            _view.OnDispose += UnsubscribeFromModel;
            _view.OnDispose += UnsubscribeFromView;
        }

        private void UnsubscribeFromView(object sender, EventArgs eventArgs)
        {
            _view.OnDispose -= UnsubscribeFromModel;
            _view.OnDispose -= UnsubscribeFromView;
        }

        private void SubscribeToModel()
        {
            _model.OnSpeedChanged += SetNewSpeed;
        }

        private void UnsubscribeFromModel(object sender, EventArgs eventArgs)
        {
            _model.OnSpeedChanged -= SetNewSpeed;
        }

        private void TransferDataModelToView()
        {
            _view.ChangeSpeed(_model.GetSpeed());
        }

        private async void SpawnCoin()
        {
            while (true)
            {
                await Task.Delay(_model.GetSpawnCoinSpeed());
                Pool.Create(_coin.gameObject, _view.gameObject.transform.position);
            }
        }

        private void SetNewSpeed(object sender, float speed) => _view.ChangeSpeed(speed);
    }
}
