using UnityEngine;
using UnityEngine.Pool;

public class Bullet : MonoBehaviour
{
    [SerializeField] float _lifetime = 5f, startLifetime = 5f, speed = 1f, boomRadius = 2.5f;
    public float lifetime
    {
        get { return _lifetime; }
        private set
        {
            if (value <= 0f)
                Die();
            _lifetime = value;
        }
    }
    [SerializeField] LayerMask boomMask;
    public IObjectPool<Bullet> pool;

    /*void Start()
    {
        startLifetime = lifetime;
    }*/

    void Update()
    {
        lifetime -= Time.deltaTime;
    }
    private void FixedUpdate()
    {
        transform.Translate(Vector3.forward * speed * Time.fixedDeltaTime);
    }

    public void ResetBullet()
    {
        lifetime = startLifetime;
    }

    void Die()
    {
        /*Collider[] colliders = Physics.OverlapSphere(transform.position, boomRadius, boomMask);

        foreach (Collider c in colliders)
        {
            if (TryGetComponent(out CharacterController controller))
            {

            }
        }*/

        pool.Release(this);
    }
}
