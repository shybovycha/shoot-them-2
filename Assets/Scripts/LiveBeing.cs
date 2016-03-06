using UnityEngine;
using System.Collections;

public class LiveBeing : MonoBehaviour, IDamageable {
    protected float health;
    protected float defaultHealth = 100;

    public event System.Action OnHit;
    public event System.Action OnDeath;

    protected bool isAlive {
        get {
            return health > 0;
        }
    }

    public virtual void TakeHit(float damage, RaycastHit hit) {
        print(System.String.Format("Hitting living being with {0} HP for {1} DMG", health, damage));

        if (health > 0) {
            health -= damage;
        }

        if (!isAlive) {
            Die();
        }

        if (OnHit != null) {
            OnHit();
        }
    }

    public virtual void Die() {
        GameObject.Destroy(gameObject);

        if (OnDeath != null) {
            OnDeath();
        }
    }

    public virtual void Start() {
        health = defaultHealth;
    }
}
