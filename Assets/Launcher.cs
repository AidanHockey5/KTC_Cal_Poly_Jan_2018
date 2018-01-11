using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launcher : MonoBehaviour
{
    public GameObject bomb;
    public float launchForce = 1000f;
	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(Input.GetMouseButtonDown(0))
        {
            Vector3 fwd = transform.forward;
            GameObject b = Instantiate(bomb, transform.position, transform.rotation);
            b.GetComponent<Rigidbody>().AddForce(fwd * launchForce);
        }
	}
}
