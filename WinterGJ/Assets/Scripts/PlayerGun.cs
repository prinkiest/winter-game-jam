using UnityEngine;

public class PlayerGun : Gun
{
    InputHandler inp;
    protected override void Start()
    {
        inp = FindAnyObjectByType<InputHandler>();

        base.Start();
    }

    void Update()
    {
        if (inp.isShooting && canShoot && pool != null)
        {
            Bullet bu = pool.Get();
            StartCoroutine(CoolDown());
        }
    }
}
