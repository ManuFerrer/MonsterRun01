using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderController : MonoBehaviour {

   
    // Use this for initialization
    void Start () {
       
    }
	
	// Update is called once per frame
	void Update () {
       
	}


    protected void OnTriggerEnter(Collider other)
    {
        other.gameObject.SetActive(false);
    }

    protected void OnTriggerStay(Collider other)
    {

        
    }

    protected void OnTriggerExit(Collider other)
    {

        
    }
}
