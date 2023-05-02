using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    //ī�޶� ���� Ÿ��
    public Transform m_target;

    //ī�޶��� ���� �ӵ� 
    public float m_smoothSpeed = 0.125f;

    //ī�޶� ���������� ���� 
    public bool followTarget = true;
    private bool b_cameraStop = true;
    void LateUpdate()
    {
        if (followTarget)
        {   // ī�޶� ���� ��ġ
            Vector3 desiredPosition = m_target.position + new Vector3(0, 0, -10);
            // �ε巯�� �̵��� ���� ���� ���
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, m_smoothSpeed);
            transform.position = smoothedPosition; 
        }

        if (GameManager.Instance.currentStageNum == 2 && b_cameraStop)
        {
            Camera.main.transform.position = new Vector3(transform.position.x + 4, transform.position.y, transform.position.z);
            b_cameraStop = false;
        }
    }
}
