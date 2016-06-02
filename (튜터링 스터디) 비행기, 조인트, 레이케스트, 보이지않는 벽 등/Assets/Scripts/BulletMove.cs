using UnityEngine;
using System.Collections;

public class BulletMove : MonoBehaviour {

    public float moveSpeed;
    Transform myTrans;

	// Use this for initialization
	void Awake () {
        myTrans = GetComponent<Transform>();
        Destroy(gameObject, 3f);
	}
	
	// Update is called once per frame
	void Update () {
        myTrans.Translate(0f, moveSpeed * Time.deltaTime, 0f);
	}
}