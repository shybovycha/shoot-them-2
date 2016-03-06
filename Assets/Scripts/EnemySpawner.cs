using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {
    public Transform[] respawnPoints;
    public Enemy enemy;

    public void Start() {
        foreach (Transform p in respawnPoints) {
            Enemy e = Instantiate(enemy, p.position, p.rotation) as Enemy;
            e.OnDeath += CountFrag;
            e.transform.parent = p;
        }
    }

    protected void CountFrag() {
        print("Enemy killed");
    }

    protected void CountHit() {
        print("Enemy hit");
    }
}
