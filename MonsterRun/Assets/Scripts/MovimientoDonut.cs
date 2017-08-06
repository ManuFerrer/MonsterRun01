using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoDonut : MonoBehaviour {
    Vector3 rotacion = new Vector3(15, 30, 45);
    Vector3 destino;
    protected float vecY;
    [SerializeField] protected int calibre;
    // Use this for initialization
    void Start () {
        vecY = transform.position.y * calibre ;
        destino = new Vector3(transform.position.x, vecY, transform.position.z);
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(rotacion * Time.deltaTime);
        transform.position = Vector3.Lerp(transform.position, destino, Time.deltaTime);
        if (Vector3.Distance(transform.position, destino) >= 0.5f)
        {
            vecY *= -1;
        }
    }
}
