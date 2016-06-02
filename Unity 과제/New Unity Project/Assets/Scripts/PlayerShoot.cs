using UnityEngine;
using System.Collections;

public class PlayerShoot : MonoBehaviour {
    
    public GameObject BulletPrefab;

	// Use this for initialization
	void Start () {
       
	}
	
	// Update is called once per frame
	void Update () {

	    if (Input.GetButtonDown("Fire1")) {
  
            var spPoint = GameObject.Find("Bulletspawn");
            Instantiate( BulletPrefab, transform.position, transform.rotation);
            
            
        }
	}
}
