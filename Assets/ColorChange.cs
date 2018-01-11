using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChange : MonoBehaviour
{
    Renderer r;
	// Use this for initialization
	void Start ()
    {
        r = GetComponent<Renderer>();
        //r.material.color = Color.red;
        StartCoroutine(Swap());
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    IEnumerator Swap()
    {
        while(true)
        {
            byte red = (byte)Random.Range(0, 255);
            byte green = (byte)Random.Range(0, 255);
            byte blue = (byte)Random.Range(0, 255);
            r.material.color = new Color32(red, green, blue, 255);
            yield return new WaitForSeconds(0.1f);
        }
    }


}
