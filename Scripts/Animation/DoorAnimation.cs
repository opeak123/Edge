using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAnimation : MonoBehaviour
{
    //Door �ִϸ����� 
    Animator doorAni;
    //���� ���ȴ��� üũ
    public bool isDoorOpened = false;
    
    private void Start()
    {
        //�Ҵ�
        doorAni = GetComponent<Animator>();
        //�ִϸ��̼� �ӵ� �ʱ�ȭ
        doorAni.speed = 0f;
    }
    public void TriggerDoorOpen()
    {
        //Open
        doorAni.speed = 1f;
        isDoorOpened = true;
        doorAni.SetTrigger("doorOpen");
        SoundManager.Instance.PlaySFX("door-open-sfx",.5f);
    }

    public void TriggerDoorClose()
    {
        //Close
        doorAni.speed = -1f;
        isDoorOpened = false;
        doorAni.SetTrigger("doorOpen");
    }

}
