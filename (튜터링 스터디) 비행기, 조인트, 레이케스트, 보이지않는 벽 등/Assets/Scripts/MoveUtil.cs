using UnityEngine;
using System.Collections;

/// <summary>
/// 지정된 캐릭터를 회전 하면서 이동하게 하는 스크립트
/// </summary>
public class MoveUtil
{
    /// <summary>
    /// 캐릭터를 프레임 별로 이동 시키고 목적지까지의 거리를 넘겨줌
    /// </summary>
    /// <param name="cc"></param>
    /// <param name="target"></param>
    /// <param name="moveSpeed"></param>
    /// <param name="turnSpeed"></param>
    /// <returns></returns>
    public static float MoveFrame(CharacterController cc,
        Transform target, float moveSpeed, float turnSpeed)
    {
        Transform t = cc.transform;
        Vector3 dir = target.position - t.position;
        Vector3 dirXZ = new Vector3(dir.x, 0f, dir.z);
        Vector3 targetPos = t.position + dirXZ;
        Vector3 framePos = Vector3.MoveTowards(
            t.position,
            targetPos,
            moveSpeed * Time.deltaTime);

        //이동
        cc.Move(framePos - t.position + Physics.gravity);

        //회전도 같이 함
        RotateToDir(t, target, turnSpeed);

        return Vector3.Distance(framePos, targetPos);
    }

    /// <summary>
    /// 캐릭터를 프레임 벼롤 회전 시키는 함수
    /// </summary>
    /// <param name="self"></param>
    /// <param name="target"></param>
    /// <param name="turnSpeed"></param>
    public static void RotateToDir(Transform self, Transform target, float turnSpeed)
    {
        Vector3 dir = target.position - self.position;
        Vector3 dirXZ = new Vector3(dir.x, 0f, dir.z);
        //회전 방향이 더이상 할 필요가 없을 경우
        if (dirXZ == Vector3.zero)
            return;

        //회전.
        self.rotation = Quaternion.RotateTowards(
            self.rotation,
            Quaternion.LookRotation(dirXZ),
            turnSpeed * Time.deltaTime);
    }

    /// <summary>
    /// 긴급히 회전 함
    /// 몬스터가 맞을때 회전 함
    /// </summary>
    /// <param name="self"></param>
    /// <param name="target"></param>
    public static void RotateToDirBurst(Transform self, Transform target)
    {
        Vector3 dir = target.position - self.position;
        Vector3 dirXZ = new Vector3(dir.x, 0f, dir.z);
        //회전 방향이 더이상 할 필요가 없을 경우
        if (dirXZ == Vector3.zero)
            return;

        //회전.
        self.rotation = Quaternion.LookRotation(dirXZ);
    }
}
