using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Script : MonoBehaviour {
    [SerializeField]
    Transform player;
    Vector3 pos_correct;
	// Use this for initialization
	void Start () {
        pos_correct = new Vector3(0, 2, -5);
        transform.position = player.transform.position + pos_correct;
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = player.transform.position + pos_correct;
    }
}
