﻿using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {
    public float speed = 10;

    void Update() {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }
}
