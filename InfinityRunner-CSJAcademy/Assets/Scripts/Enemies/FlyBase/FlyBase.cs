using UnityEngine;

public class FlyBase : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rig;
    [SerializeField] private float _speed;

    void Start()
    {
        Destroy(gameObject, 5.0f);
    }

    public void UpdateVelocity()
    {
        rig.linearVelocity = Vector2.left * _speed;
    }
}
