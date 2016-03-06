using UnityEngine;
using UnityEngine.SceneManagement;

using System.Linq;
using System.Collections;
using System.Collections.Generic;

public class EnemySpawner : MonoBehaviour {
    [System.Serializable]
    public class RespawnPoint {
        public Transform point;
        public Enemy enemy;
        public uint enemyCount = 1;
    }

    public RespawnPoint[] respawnPoints;
    protected List<Enemy> aliveEnemies;

    public void Start() {
        if (respawnPoints.Length < 1) {
            return;
        }

        aliveEnemies = new List<Enemy>();

        foreach (RespawnPoint p in respawnPoints) {
            for (uint i = 0; i < p.enemyCount; i++) {
                Enemy e = Instantiate(p.enemy, p.point.position, p.point.rotation) as Enemy;
                e.OnDeath += CountFrag;
                e.transform.parent = p.point;
                aliveEnemies.Add(e);
            }
        }
    }

    protected void CountFrag(LiveBeing e) {
        // print(string.Format("Enemy {0} killed", e.name));

        aliveEnemies.Remove(e as Enemy);

        CheckIfLevelClear();
    }

    protected void CheckIfLevelClear() {
        if (aliveEnemies.Count < 1) {
            NextLevel();
            // print("Next level!");
        }
    }

    protected void NextLevel() {
        /*if (SceneManager.sceneCount < 2) {
            print(string.Format("No more levels ({0}). Shutting down...", SceneManager.sceneCount));
            Application.Quit();
            return;
        }*/

        Scene currentScene = SceneManager.GetActiveScene();
        int currentSceneIndex = currentScene.buildIndex;

//        if (currentSceneIndex >= SceneManager.sceneCount - 1) {
//            print("This was the last level. Shutting down...");
//            Application.Quit();
//            return;
//        }

        SceneManager.LoadScene(currentSceneIndex + 1);
    }
}
