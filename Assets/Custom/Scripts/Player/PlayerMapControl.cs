using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMapControl : MonoBehaviour {

   public Camera mapCam;

	// Use this for initialization
	void Start () {
        //mapCam = GameObject.FindGameObjectWithTag("MapCam").GetComponent<Camera>();
        mapCam.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown("m"))
        {
            mapCam.enabled = !mapCam.enabled;
        }
	}
}
