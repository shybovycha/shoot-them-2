using UnityEngine;
using System.Collections;

public class GunController : MonoBehaviour {
    protected Gun currentGun;

    public Gun defaultGun;
    public Transform weaponPivot;

    public void Start() {
        if (defaultGun != null) {
            EquipGun(defaultGun);
        }
    }

    public void EquipGun(Gun newGun) {
        if (currentGun != null) {
            Destroy(currentGun.gameObject);
        }

        currentGun = Instantiate(newGun, weaponPivot.position, weaponPivot.rotation) as Gun;
        currentGun.transform.parent = weaponPivot;
    }

    public void Shoot() {
        if (currentGun == null) {
            return;
        }

        currentGun.Shoot();
    }
}
