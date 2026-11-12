using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D _rig;

    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;

    void Start()
    {
        _rig = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        PlayerMoviments.MovePlayer(_rig, _speed);
    }

    void Update()
    {
        PlayerInputs.InputsMoviment(_rig, _jumpForce);
    }
}
