using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {
    public float speed = 10;
    public float lifetime = 5;
    public float damage = 1;
    public LayerMask collisionMask;

    void Start() {
        StartCoroutine(DestroyOnTimeout());
    }

    void Update() {
        float moveDistance = speed * Time.deltaTime;

        CheckCollisions(moveDistance);

        transform.Translate(Vector3.forward * moveDistance);
    }

    void CheckCollisions(float distance) {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, distance, collisionMask, QueryTriggerInteraction.Collide)) {
            OnHitObject(hit);
        }
    }

    IEnumerator DestroyOnTimeout() {
        yield return new WaitForSeconds(lifetime);

        if (gameObject != null) {
            GameObject.Destroy(gameObject);
        }
    }

    void OnHitObject(RaycastHit hit) {
        // Damage enemy
        IDamageable target = hit.collider.GetComponent<IDamageable>();

        // print(System.String.Format("Hit {0}", hit.collider.name));

        if (target != null) {
            target.TakeHit(damage, hit);
        }

        // Destroy bullet
        GameObject.Destroy(gameObject);
    }
}
