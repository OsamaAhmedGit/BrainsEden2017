using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    private GameObject player;

    private Vector3 offset;

	void Start () {

        offset = transform.position;
	}
	
	void Update () {

        if(player == null)
            player = GameObject.Find("Player(Clone)");
        else
            transform.position = player.transform.position + offset;
	}
}
