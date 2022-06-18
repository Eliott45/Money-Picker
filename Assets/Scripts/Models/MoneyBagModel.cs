using System;

namespace Models
{
    public class MoneyBagModel 
    {
        public event EventHandler<float> OnSpeedChanged;
        
        public float Speed { get; private set; }
        public float SpawnCoinSpeed { get; }

        public MoneyBagModel(float speed, float spawnCoinSpeed)
        {
            Speed = speed;
            SpawnCoinSpeed = spawnCoinSpeed;
        }
        
        public void IncreaseSpeed(float speed)
        {
            Speed = speed;
            OnSpeedChanged?.Invoke(this, speed);
        }
    }
}
