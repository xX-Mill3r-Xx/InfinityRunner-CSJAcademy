using UnityEngine;

public class Plataform : MonoBehaviour
{
    [SerializeField] private Transform _finalPoint;
    [SerializeField] private SpawnGroundEnemies _spawnGroundEnemies;
    public Transform FinalPoint { get => _finalPoint; set => _finalPoint = value; }
    public SpawnGroundEnemies SpawnGroundEnemies { get => _spawnGroundEnemies; set => _spawnGroundEnemies = value; }
}
