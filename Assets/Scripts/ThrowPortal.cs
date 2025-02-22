﻿using UnityEngine;
using System.Collections;

public class ThrowPortal : MonoBehaviour {

	public GameObject leftPortal;
	public GameObject rightPortal;

	GameObject mainCamera;

	// Use this for initialization
	void Start () {
		mainCamera = GameObject.FindWithTag("MainCamera");
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("Fire1")) {
			Debug.Log ("left click");
			throwPortal(leftPortal);
		}
		if(Input.GetButtonDown("Fire2")) {
			Debug.Log ("right click");
			throwPortal(rightPortal);
		}
	}

	void throwPortal(GameObject portal) {
		int x = Screen.width / 2;
		int y = Screen.height / 2;

		Ray ray = mainCamera.GetComponent<Camera>().ScreenPointToRay(new Vector3(x,y));
		RaycastHit hit;
		if(Physics.Raycast(ray, out hit)) {
			Quaternion hitObjectRotation = Quaternion.LookRotation(hit.normal);
			portal.transform.position = hit.point;
			portal.transform.rotation = hitObjectRotation;
		}
	}
}
