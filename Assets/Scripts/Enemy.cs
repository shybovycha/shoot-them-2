using UnityEngine;
using System.Collections;

public class Enemy : LiveBeing {
    public ParticleSystem hitEffect;

    public override void Start() {
        base.Start();
    }

    public override void TakeHit(float damage, Vector3 hitPosition, Vector3 hitDirection) {
        base.TakeHit(damage, hitPosition, hitDirection);

        Destroy(Instantiate(hitEffect.gameObject, hitPosition, Quaternion.FromToRotation(Vector3.forward, hitDirection)) as GameObject, hitEffect.startLifetime);
    }
}
