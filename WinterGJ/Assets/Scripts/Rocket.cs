using UnityEngine;

public class Rocket : Bullet
{
    AudioSource aSo;
    [SerializeField] AudioClip[] boomClips;

    void Start()
    {
        aSo = GetComponent<AudioSource>();
    }

    protected override void Die()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, boomRadius, boomMask);

        foreach (Collider c in colliders)
        {
            Vector3 boomVec = (transform.position - c.transform.position) * boomForce * (boomRadius - Vector3.Distance(transform.position, c.transform.position));
            if (c.TryGetComponent(out Rigidbody rb))
            {
                rb.AddForce(boomVec);
            }
            if (c.TryGetComponent(out CharacterController con))
            {
                //con.Move(con.transform.position + boomVec * Time.deltaTime);
            }
        }

        if (aSo != null && boomClips != null)
            aSo.PlayOneShot(boomClips[Random.Range(0, boomClips.Length)], 1f);
        base.Die();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, boomRadius);
    }
}
