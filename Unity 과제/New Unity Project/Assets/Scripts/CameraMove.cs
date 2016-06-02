using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour
{
    Transform myTrans;
    public Transform player;

    public float smoothTime = 1f; //얼마나 부드러운지
    private Vector3 currentVelocity = Vector3.zero; //벡터3값을 모두 0으로 줌

    public float cameraTurn = 2f;
    // Use this for initialization
    void Awake()
    {
        myTrans = GetComponent<Transform>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    } //플레이어에 태그해줌

    // Update is called once per frame
    void LateUpdate()
    {
        myTrans.position = Vector3.SmoothDamp(myTrans.position, player.position, ref currentVelocity, smoothTime); //ref을 사용하면 참조 값을 가진다.
        myTrans.rotation = Quaternion.Slerp(myTrans.rotation, player.rotation, cameraTurn * Time.deltaTime);
    }
}