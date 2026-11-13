using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Pool;

public class PlayerShooter : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Bullet projectilePrefab;
    [SerializeField] private Transform muzzle;
    [SerializeField] private InputActionReference fireAction;

    [Header("Config")]
    [SerializeField] private float shotsPerSecond = 5f;
    [SerializeField] private bool autoFire = true;

    private IObjectPool<Bullet> _pool;
    private float _nextFireTime;

    private void Awake()
    {
        _pool = new ObjectPool<Bullet>(
            createFunc: CreateProjectile,
            actionOnGet: p => p.gameObject.SetActive(true),
            actionOnRelease: p => p.gameObject.SetActive(false),
            actionOnDestroy: p =>
            {
                // Unity sobrescreve == / != para detectar objetos destruídos.
                if (p != null)
                    Destroy(p.gameObject);
            },
            collectionCheck: true,
            defaultCapacity: 16,
            maxSize: 64
        );
    }

    private Bullet CreateProjectile()
    {
        Bullet instance = Instantiate(projectilePrefab);
        instance.Pool = _pool;
        return instance;
    }

    private void OnEnable()
    {
        if (fireAction != null) fireAction.action.Enable();
    }

    private void OnDisable()
    {
        if (fireAction != null) fireAction.action.Disable();
    }

    private void Update()
    {
        bool wantsToFire = autoFire || (fireAction != null && fireAction.action.IsPressed());
        if (!wantsToFire || Time.time < _nextFireTime) return;

        Fire();
        _nextFireTime = Time.time + 1f / shotsPerSecond;
    }

    private void Fire()
    {
        Bullet bullet = _pool.Get();
        // Direção para frente do player (ajuste para transform.up se o sprite apontar para cima)
        Vector2 direction = transform.right;
        bullet.Launch(muzzle.position, direction);
    }
}
