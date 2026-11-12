using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D _rig;

    [Header("Configs")]
    [SerializeField] private Animator _anim;
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;

    [Header("Jump Settings")]
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
        if (PlayerInputs.JumpPressed() && _jumpsLeft > 0)
        {
            PlayerInputs.ApplyJumpForce(_rig, _jumpForce);
            _anim.SetBool("jump", true);

            _jumpsLeft--;
        }
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