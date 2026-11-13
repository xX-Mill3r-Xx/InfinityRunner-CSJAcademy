using System.Collections.Generic;
using UnityEngine;

public class SpawnGroundEnemies : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private List<Transform> _points = new List<Transform>();
    private GameObject _currentEnemy;

    void Start()
    {
        CreateEnemy();
    }

    void Update()
    {
        
    }

    private void CreateEnemy()
    {
        int pos = Random.Range(0, _points.Count);

        GameObject gameObj = Instantiate(
            _enemyPrefab,
            _points[pos].position,
            _points[pos].rotation);

        _currentEnemy = gameObj;
    }

    public void SpawnEnemyes()
    {
        if (_currentEnemy == null)
        {
            CreateEnemy();
        }
    }
}
