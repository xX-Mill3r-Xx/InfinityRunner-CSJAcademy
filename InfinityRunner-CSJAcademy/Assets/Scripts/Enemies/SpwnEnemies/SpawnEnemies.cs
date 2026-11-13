using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    #region Properties
    [Header("Configurações")]
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
        if (_enimiesList.Count == 0) return;

        int randomIndex = Random.Range(0, _enimiesList.Count);
        GameObject enemyToSpawn = _enimiesList[randomIndex];

        Vector3 spawnPos = new Vector3(
            transform.position.x,
            transform.position.y + Random.Range(1.0f, 3.0f),
            0f);

        Instantiate(enemyToSpawn, spawnPos, transform.rotation);
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