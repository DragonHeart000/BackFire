using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;
using UnityEngine.UI;

public class PlayerCountText : MonoBehaviour {

    public TextMeshProUGUI text;

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        text.text = "Players: " + NetworkServer.connections.Count;
    }
}
