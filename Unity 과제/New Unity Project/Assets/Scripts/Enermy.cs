using UnityEngine;
using System.Collections;

public class Enermy : MonoBehaviour {

    public GameObject Explosion;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    void OnCollisionEnter(Collision other)
    {
        Debug.Log(other);
        if (other.transform.CompareTag("Player"))
        {
            Instantiate(Explosion, transform.position, transform.rotation);
            Destroy(other.gameObject);
            Destroy(this.gameObject);
            Application.LoadLevel(0);
        }
        if (other.transform.tag == "Bullet")
        {
            Instantiate(Explosion, transform.position, transform.rotation);
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }
}
