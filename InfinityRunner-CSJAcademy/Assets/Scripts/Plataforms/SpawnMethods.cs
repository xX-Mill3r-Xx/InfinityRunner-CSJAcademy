using System.Collections.Generic;
using UnityEngine;

public static class SpawnMethods
{
    #region Properties

    private static List<Transform> _currentPlataforms = new List<Transform>();
    private static Transform _currentPlataformPoint;
    private static Transform _previousPlataform;
    private static int _plataformIndex;
    private const float Distance = 30.0f;
    private const float TriggerDistance = 3f;
    private static float _xOffSet;
    private static float _yOffSet;

    #endregion

    public static void InstantiatePlataforms(List<GameObject> plataforms, Quaternion rotation)
    {
        _currentPlataforms.Clear();
        _plataformIndex = 0;
        _previousPlataform = null;
        _xOffSet = 0;
        _yOffSet = -4.0F;

        for (int i = 0; i < plataforms.Count; i++)
        {
            Transform plataform = Object.Instantiate(
                plataforms[i],
                new Vector2(_xOffSet, _yOffSet),
                rotation
            ).transform;

            _currentPlataforms.Add(plataform);
            _xOffSet += Distance;
        }

        SetCurrentPoint();
    }

    private static void SetCurrentPoint()
    {
        var plataform = _currentPlataforms[_plataformIndex].GetComponentInChildren<Plataform>();
        if (plataform == null || plataform.FinalPoint == null)
        {
            Debug.LogError($"Olataforma '{_currentPlataforms[_plataformIndex].name}' sem script Plataform ou sem FinalPoint atribuído.");
            return;
        }

        _currentPlataformPoint = plataform.FinalPoint;
    }

    public static void LoopMovePlataforms(Transform player)
    {
        if (_currentPlataformPoint == null)
            return;

        float distanceToEnd = _currentPlataformPoint.position.x - player.position.x;

        if(distanceToEnd <= TriggerDistance)
        {
            if (_previousPlataform != null)
                Recycle(_previousPlataform);

            _previousPlataform = _currentPlataforms[_plataformIndex];
            _plataformIndex = (_plataformIndex + 1) % _currentPlataforms.Count;

            SetCurrentPoint();
        }
    }

    public static void Recycle(Transform plataform)
    {
        plataform.transform.position = new Vector2(_xOffSet, 0);
        _xOffSet += Distance;
    }
}
