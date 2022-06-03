using UnityEngine;

public class MoneyBag : MonoBehaviour
{
    [Header("Set In Inspector")]
    [SerializeField] private GameObject _applePrefab;
    [SerializeField] private float _speed = 1f; 
    [SerializeField] private float _changeDistance = 10f; 
    [SerializeField] private float _chanceToChangeDirections = .1f; 
    [SerializeField] private float _secondsBetweenAppleDrops = 1f;

    private void Start () {
        InvokeRepeating(nameof(DropCoin), 0, _secondsBetweenAppleDrops);
    }
    
    private void Update ()
    {
        Move();
    }

    private void FixedUpdate()
    {
        ChangeDirection();
    }
    
    private void DropCoin()
    {
        Instantiate(_applePrefab, transform.position, Quaternion.identity);
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

    private void ChangeDirection()
    {
        if ( Random.value < _chanceToChangeDirections) { 
            _speed *= -1; 
        }
    }
}
