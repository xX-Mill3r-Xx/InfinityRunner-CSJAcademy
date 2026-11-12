using System.Collections.Generic;
using UnityEngine;

public class SpawnPlataforms : MonoBehaviour
{
    #region Properties

    [SerializeField] private List<GameObject> _plataforms = new List<GameObject>();
    private Transform _transform;
    private Transform _player;

    #endregion

    void Start()
    {
        ConfigStart();
    }

    void Update()
    {
        SpawnMethods.LoopMovePlataforms(_player);
    }

    private void ConfigStart()
    {
        _player = GameObject.FindGameObjectWithTag("Player").transform;

        _transform = transform;
        SpawnMethods.InstantiatePlataforms(_plataforms, transform.rotation);
    }
}
