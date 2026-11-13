using UnityEngine;

public class BombEnemy : MonoBehaviour
{
    [SerializeField] private GameObject _bombPrefab;
    [SerializeField] private float _thowTime;
    [SerializeField] private float _thowCount;
    [SerializeField] private Transform _firePoint;

    void Update()
    {
        _thowCount += Time.deltaTime;

        if (_thowCount >= _thowTime)
        {
            Instantiate(_bombPrefab, _firePoint.position, _firePoint.rotation);
            _thowCount = 0.0f; 
        }
    }
}
