using UnityEngine;
using UnityEngine.Pool;
using System.Collections;

public abstract class Gun : MonoBehaviour
{
    [SerializeField] protected float coolDown = .5f;
    [SerializeField] protected Bullet bulletPrefab;
    [SerializeField] protected Transform shootPoint;
    protected ObjectPool<Bullet> pool;
    protected bool canShoot = true;

    protected virtual void Start()
    {
        if (shootPoint == null)
            shootPoint = transform;

        pool = new ObjectPool<Bullet>(() =>
        {
            Bullet bullet = Instantiate(bulletPrefab);
            bullet.pool = pool;
            bullet.transform.position = shootPoint.position;
            bullet.transform.rotation = shootPoint.rotation;
            return bullet;
        }, bullet =>
        {
            bullet.ResetBullet();
            bullet.gameObject.SetActive(true);
            bullet.transform.position = shootPoint.position;
            bullet.transform.rotation = shootPoint.rotation;
        }, bullet =>
        {
            bullet.gameObject.SetActive(false);
        }, bullet =>
        {
            Destroy(bullet.gameObject);
        }, false, 100, 800
        );
    }

    protected virtual IEnumerator CoolDown()
    {
        canShoot = false;
        yield return new WaitForSeconds(coolDown);
        canShoot = true;
    }
}
