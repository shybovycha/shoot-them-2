using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;

[RequireComponent(typeof(GunController))]
public class MainCharacterController : FirstPersonController {
    protected GunController gunController;

    protected override void Start() {
        base.Start();

        gunController = GetComponent<GunController>();
    }

    protected override void Update() {
        base.Update();

        if (Input.GetButtonDown("Fire1")) {
            // GetComponent<Animation>().Play("DoubleBarrelShoot");
            gunController.Shoot();
        }
    }
}
