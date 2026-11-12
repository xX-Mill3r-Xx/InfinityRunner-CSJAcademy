using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    #region Properties

    [SerializeField] private List<GameObject> _enimiesList = new List<GameObject>();
    [SerializeField] private float _spawnTime;

    private float _timerCount;

    #endregion

    void Start()
    {
        SpawnEnemy();
    }

    void Update()
    {
        SpawnCronometrer();
    }

    void SpawnEnemy()
    {
        Instantiate(
            _enimiesList[0],
            transform.position + new Vector3(
                0,
                Random.Range(1.0f, 3.0f),
                0),
            transform.rotation);
    }

    public void SpawnCronometrer()
    {
        _timerCount += Time.deltaTime;

        if (_timerCount >= _spawnTime)
        {
            SpawnEnemy();
            _timerCount = 0.0f;
        }
    }
}
