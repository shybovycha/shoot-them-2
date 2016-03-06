using UnityEngine;
using System.Collections;

public interface IDamageable {
    void TakeHit(float damage, Vector3 hitPosition, Vector3 hitDirection);
}
