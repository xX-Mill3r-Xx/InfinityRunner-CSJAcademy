using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D _rig;

    [Header("Configs")]
    [SerializeField] private Animator _anim;
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;

    [Header("Jump Settings")]
    [SerializeField] private float _secondJumpMultiplier = 100000.0f;
    private int _maxJumps = 2; 
    private int _jumpsLeft;    

    void Start()
    {
        _rig = GetComponent<Rigidbody2D>();
        _jumpsLeft = _maxJumps; 
    }

    void FixedUpdate()
    {
        PlayerMoviments.MovePlayer(_rig, _speed);
    }

    void Update()
    {
        JumpPlayer();
    }

    private void JumpPlayer()
    {
        if (PlayerInputs.JumpPressed() && _jumpsLeft > 0)
        {
            DoubleJump();

            PlayerInputs.ApplyJumpForce(_rig, _jumpForce);
            _anim.SetBool("jump", true);

            _jumpsLeft--;
        }
    }

    private void DoubleJump()
    {
        bool isFirstJump = _jumpsLeft == _maxJumps;
        float force = isFirstJump ? _jumpForce : _jumpForce * _secondJumpMultiplier;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 3) 
        {
            _anim.SetBool("jump", false);
            _jumpsLeft = _maxJumps; 
        }
    }
}