using UnityEngine;
using UnityEngine.Pool;

public class Bullet : MonoBehaviour
{
    [SerializeField] protected float _lifetime = 5f, startLifetime = 5f, speed = 1f, boomRadius = 2.5f, boomForce = 25f;
    public float lifetime
    {
        get { return _lifetime; }
        protected set
        {
            if (value <= 0f)
                Die();
            _lifetime = value;
        }
    }
    [SerializeField] protected LayerMask boomMask;
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

    protected virtual void Die()
    {
        pool.Release(this);
    }
}
