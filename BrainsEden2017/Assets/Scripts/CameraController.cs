using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    private GameObject player;

    private Vector3 offset;

	void Start () {

		offset.z = -5;
	}
	
	void Update () {

        if(player == null)
            player = GameObject.Find("Player");
        else
			transform.position = new Vector3 (player.transform.position.x, player.transform.position.y, player.transform.position.z + offset.z);
	}
}
