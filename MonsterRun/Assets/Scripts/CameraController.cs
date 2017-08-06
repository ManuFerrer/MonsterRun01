using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    [SerializeField] protected GameObject tarjet;
    [SerializeField] protected float distance;
    [SerializeField] protected Transform player;

    protected float MyZ;


	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        float distZ = tarjet.transform.position.z;

        MyZ = distZ - distance;

        transform.position = new Vector3(transform.position.x, transform.position.y, MyZ);

        transform.LookAt(player);
	}
}
