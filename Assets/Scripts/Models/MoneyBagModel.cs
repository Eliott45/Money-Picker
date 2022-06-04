using System;

namespace Models
{
    public class MoneyBagModel 
    {
        public event EventHandler<float> OnSpeedChanged;
        
        private float _speed;
        private readonly float _spawnCoinSpeed;

        public MoneyBagModel(float speed, float spawnCoinSpeed)
        {
            _speed = speed;
            _spawnCoinSpeed = spawnCoinSpeed;
        }

        public float GetSpeed() => _speed;
        
        public int GetSpawnCoinSpeed() => (int)(_spawnCoinSpeed / 0.1 * 100);

        public void IncreaseSpeed(float speed)
        {
            _speed = speed;
            OnSpeedChanged?.Invoke(this, speed);
        }
    }
}
