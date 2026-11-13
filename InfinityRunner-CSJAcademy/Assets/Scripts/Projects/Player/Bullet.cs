using UnityEngine;
using UnityEngine.Pool;

public class Bullet : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] private float speed = 12f;
    [SerializeField] private float lifetime = 2f;
    [SerializeField] private int damage = 1;

    private Rigidbody2D _rb;
    private IObjectPool<Bullet> _pool;
    private float _despawnTime;
    private bool _released;

    public IObjectPool<Bullet> Pool
    {
        set => _pool = value;
    }

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _rb.bodyType = RigidbodyType2D.Kinematic;
    }

    public void Launch(Vector2 position, Vector2 direction)
    {
        _released = false;
        transform.position = position;
        transform.right = direction;
        _rb.linearVelocity = direction.normalized * speed;
        _despawnTime = Time.time + lifetime;
    }

    private void Update()
    {
        if (!_released && Time.time >= _despawnTime)
            Despawn();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) return;

        Despawn();
    }

    private void Despawn()
    {
        if (_released) return;
        _released = true;
        _rb.linearVelocity = Vector2.zero;
        _pool.Release(this);
    }
}
