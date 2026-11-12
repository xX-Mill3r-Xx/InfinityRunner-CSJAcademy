using System.Collections.Generic;
using UnityEngine;

public class SpawnPlataforms : MonoBehaviour
{
    public List<GameObject> _plataforms = new List<GameObject>();

    void Start()
    {
        Loop(_plataforms);
    }

    void Update()
    {

    }

    public void Loop(List<GameObject> plataforms)
    {
        for (int i = 0; i < plataforms.Count; i++)
        {
            Instantiate(plataforms[i], new Vector2(0, 0), transform.rotation);
        }
    }
}
