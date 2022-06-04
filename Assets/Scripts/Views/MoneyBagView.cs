using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Views
{
    public class MoneyBagView : MonoBehaviour
    {
        [SerializeField] private float _speed = 1f;
        [SerializeField] private float _changeDistance = 10f;
        [SerializeField] private float _chanceToChangeDirections = .1f;

        public event EventHandler OnDispose;
        
        private void Update()
        {
            Move();
        }
        
        private void FixedUpdate()
        {
            AttemptChangeMovementDirection();
        }

        private void OnDisable()
        {
            OnDispose?.Invoke(this, EventArgs.Empty);
        }

        public void ChangeSpeed(float speed)
        {
            _speed = speed;
        }
        
        private void Move()
        {
            var bagTransform = transform;
            var pos = bagTransform.position;
            pos.x += _speed * Time.deltaTime;
            bagTransform.position = pos; 
            if ( pos.x < -_changeDistance) { 
                _speed = Mathf.Abs(_speed); 
            } else if ( pos.x > _changeDistance) {
                _speed = -Mathf.Abs(_speed);
            }
        }
        
        private void AttemptChangeMovementDirection()
        {
            if ( Random.value < _chanceToChangeDirections) { 
                _speed *= -1; 
            }
        }
    }
}
