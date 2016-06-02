using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour
{
    private Transform myTrans;
    private float h;
    private float v;

    public float t; //총알
    public float moveSpeed;
    public float turnSpeed;
    public GameObject bullet; //게임오브젝트 총알
    public Transform bulletSpawn; //총알생성


    void Awake()
    {
        myTrans = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        v = Input.GetAxis("Vertical");    // 수직
        h = Input.GetAxis("Horizontal");  // 수평

        Vector3 moveDir = new Vector3(0f, v, 0f);
        myTrans.Translate(moveDir * moveSpeed * Time.deltaTime);
        myTrans.Rotate(0f, 0f, -h * turnSpeed * Time.deltaTime);

        if (Input.GetKeyDown("Fire1")) //Fire1(z키) 누르는 순간 총알 발사
            Instantiate(bullet, bulletSpawn.position, bulletSpawn.rotation);
        //이건 유니티 자체 동적할당     프리펩, 생성위치, 생성 방향

    }
}