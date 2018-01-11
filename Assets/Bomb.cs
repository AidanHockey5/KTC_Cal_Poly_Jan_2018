using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Bomb : MonoBehaviour
{
    public float boomTime = 5f;
    public float power = 10f;
    public float radius = 10f;
    public GameObject expPtc;
    public AudioClip expSound;

    // Use this for initialization
    void Start ()
    {
        Invoke("Explosion", boomTime);
	}
	
	void Explosion ()
    {
        Vector3 expPos = transform.position;
        Collider[] cols = Physics.OverlapSphere(expPos, radius);
        foreach(Collider hit in cols)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            if (rb != null)
                rb.AddExplosionForce(power, expPos, radius, 3.0f);
            else if(hit.gameObject.tag == "enemy")
            {
                GameObject en = hit.gameObject;
                en.GetComponent<NavMeshAgent>().enabled = false;
                Rigidbody erb = en.AddComponent<Rigidbody>();
                en.GetComponent<Enemy>().enabled = false;
                erb.AddExplosionForce(power, expPos, radius, 3.0f);
                Destroy(en, 20f);
            }
        }
        GameObject ptc = Instantiate(expPtc, expPos, Quaternion.identity);
        AudioSource.PlayClipAtPoint(expSound, expPos);
        Destroy(ptc, 10f);
        Destroy(gameObject);
	}
}
