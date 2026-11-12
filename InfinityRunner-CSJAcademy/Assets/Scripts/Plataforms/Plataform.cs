using UnityEngine;

public class Plataform : MonoBehaviour
{
    [SerializeField] private Transform _finalPoint;
    public Transform FinalPoint { get => _finalPoint; set => _finalPoint = value; }
}
