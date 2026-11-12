using System.Collections.Generic;
using UnityEngine;

public class SpawnPlataforms : MonoBehaviour
{
    [SerializeField] private List<GameObject> _plataforms = new List<GameObject>();
    private Transform _transform;

    void Start()
    {
        _transform = transform;
        SpawnMethods.Loop(_plataforms, transform.rotation);
    }

    void Update()
    {

    }
}
