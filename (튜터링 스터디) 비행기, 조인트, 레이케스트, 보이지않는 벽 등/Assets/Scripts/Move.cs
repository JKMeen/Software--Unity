using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {
    private Transform myTrans;
    private float h;
    private float v;

    public float t;
    public float moveSpeed;
    public float turnSpeed;
    public GameObject bullet;
    public Transform bulletSpawn;

	void Awake () {
        myTrans = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
        v = Input.GetAxis("Vertical");
        h = Input.GetAxis("Horizontal");

        Vector3 moveDir = new Vector3(0f, v, 0f);
        myTrans.Translate(moveDir * moveSpeed * Time.deltaTime);
        myTrans.Rotate(0f, 0f, -h * turnSpeed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space))
            Instantiate(bullet, bulletSpawn.position, bulletSpawn.rotation);
	}
}