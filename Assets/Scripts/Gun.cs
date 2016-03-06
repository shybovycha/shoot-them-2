using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour {
    public Transform muzzle;
    public Projectile projectile;
    public int fireRate = 10;
    public float muzzleVelocity = 35;

    double nextShotTime;

    double shotDelay {
        get { 
            return 1.0 / fireRate;
        }
    }

    public void Shoot() {
        if (Time.time < nextShotTime) {
            return;
        }

        Projectile bullet = Instantiate(projectile, muzzle.position, muzzle.rotation) as Projectile;
        bullet.speed = muzzleVelocity;

        nextShotTime = Time.time + shotDelay;
    }
}
