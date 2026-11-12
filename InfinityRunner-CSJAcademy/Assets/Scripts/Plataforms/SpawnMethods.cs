using System.Collections.Generic;
using UnityEngine;

public static class SpawnMethods
{
    private static int _distance = 30;
    private static float _offSet;

    public static void Loop(List<GameObject> plataforms, Quaternion rotation)
    {
        for (int i = 0; i < plataforms.Count; i++)
        {
            Object.Instantiate(plataforms[i], new Vector2(i * _distance, 0), rotation);
            _offSet += 30.0f;
        }
    }

    public static void Recycle(Transform plataform, Object obj)
    {
        plataform.transform.position = new Vector2 (_offSet, 0);
        _offSet += 30.0f;
    }
}
