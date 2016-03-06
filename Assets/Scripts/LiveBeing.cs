using UnityEngine;
using System.Collections;

public class LiveBeing : MonoBehaviour, IDamageable {
    protected float health;
    protected float defaultHealth = 100;

    public delegate void OnDeathEventHandler(LiveBeing e);

    public event OnDeathEventHandler OnDeath;

    protected bool isAlive {
        get {
            return health > 0;
        }
    }

    public virtual void TakeHit(float damage, Vector3 hitPosition, Vector3 hitDirection) {
        if (health > 0) {
            health -= damage;
        }

        if (!isAlive) {
            Die();
        }
    }

    public virtual void Die() {
        GameObject.Destroy(gameObject);

        if (OnDeath != null) {
            OnDeath(this);
        }
    }

    public virtual void Start() {
        health = defaultHealth;
    }
}
