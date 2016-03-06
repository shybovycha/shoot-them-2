using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour {

	void Update() {
		if (Input.GetButtonDown("Fire1")) {
			GetComponent<Animation>().Play("DoubleBarrelShoot");
		}

		if (Input.GetKeyDown(KeyCode.P)) {
			Application.CaptureScreenshot("Screenshot.png");
		}
	}
}
