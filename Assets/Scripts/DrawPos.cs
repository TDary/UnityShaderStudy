using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawPos:MonoBehaviour
{
    public Transform centerPos;
    public Transform targetPos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ClickButton()
    {

    }

    public Vector3 GetTartgetPos(Transform target, Transform center)
    {
        Vector3 result = new Vector3(0,0,0);
        Vector3 v1 = target.position - center.position;
        result.x = Vector3.Dot(v1, center.right);
        result.y = Vector3.Dot(v1, center.up);
        result.z = Vector3.Dot(v1, center.forward);
        return result;
    }

    //使用空间变换矩阵,第一种
    public Vector3 GetTargetPos(Transform target, Transform center)
    {
        return center.InverseTransformPoint(target.position);
    }
    //第二种
    public Vector3 GetTargetPos2(Transform target, Transform center)
    {
        Matrix4x4 m4 = center.worldToLocalMatrix;
        return m4.MultiplyPoint3x4(target.position);
    }
    //第三种
    public Vector3 GetTargetPos3(Transform target, Transform center)
    {
        Vector4 v4 = new Vector4(target.position.x, target.position.y, target.position.z, 1);
        return center.worldToLocalMatrix * v4;
    }
    public void OnDrawGizmos()
    {
        //绿色小球绘制
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(centerPos.position, 0.1f);
        Gizmos.DrawSphere(targetPos.position, 0.1f);
        //坐标辅助线绘制
        Gizmos.color = Color.red;
        Gizmos.DrawLine(centerPos.position, centerPos.position + centerPos.right * 10);
        Gizmos.color = Color.green;
        Gizmos.DrawLine(centerPos.position, centerPos.position + centerPos.up * 10);
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(centerPos.position, centerPos.position + centerPos.forward * 10);
        //向量绘制
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(centerPos.position, targetPos.position);

        Vector3 v3 = GetTartgetPos(targetPos, centerPos);
        //垂线绘制
        Gizmos.color = Color.white;
        Gizmos.DrawLine(targetPos.position, centerPos.position + v3.x * centerPos.right);
        Gizmos.DrawLine(targetPos.position, centerPos.position + v3.y * centerPos.up);
        Gizmos.DrawLine(targetPos.position, centerPos.position + v3.z * centerPos.forward);
        //小球绘制
        Gizmos.DrawSphere(centerPos.position + v3.x * centerPos.right, 0.1f);
        Gizmos.DrawSphere(centerPos.position + v3.y * centerPos.up, 0.1f);
        Gizmos.DrawSphere(centerPos.position + v3.z * centerPos.forward, 0.1f);
    }
}
