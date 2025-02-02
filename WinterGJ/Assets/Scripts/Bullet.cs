using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float _lifetime = 5f, speed = 1f, boomRadius = 2.5f;
    public float lifetime
    {
        get { return _lifetime; }
        set
        {
            if (value <= 0f)
                Explode();
            _lifetime = value;
        }
    }
    [SerializeField] LayerMask boomMask;

    void Start()
    {
        
    }

    void Update()
    {
        lifetime -= Time.deltaTime;
    }
    private void FixedUpdate()
    {
        transform.Translate(Vector3.forward * speed * Time.fixedDeltaTime);
    }

    void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, boomRadius, boomMask);

        foreach (Collider c in colliders)
        {
            if (TryGetComponent(out CharacterController controller))
            {

            }
        }

        Destroy(gameObject);
    }
}
