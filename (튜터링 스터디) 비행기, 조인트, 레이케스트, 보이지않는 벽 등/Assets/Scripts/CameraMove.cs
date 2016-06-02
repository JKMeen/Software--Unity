using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour {
    Transform myTrans;
    public Transform player;

    public float smoothTime = 1f;
    private Vector3 currentVelocity = Vector3.zero;

    public float cameraTurn = 1f;
	// Use this for initialization
	void Awake () {
        myTrans = GetComponent<Transform>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
	}
	
	// Update is called once per frame
	void LateUpdate () {
        myTrans.position = Vector3.SmoothDamp(myTrans.position, player.position, ref currentVelocity, smoothTime);
        myTrans.rotation = Quaternion.Slerp(myTrans.rotation, player.rotation, cameraTurn * Time.deltaTime);
	}
}