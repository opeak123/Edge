using System;
using UnityEngine;
public class UIAnimation : MonoBehaviour
{
    //UI �ִϸ��̼�
    private Animator UIanimator;
    void Start()
    {
        //�Ҵ�
        UIanimator = GetComponent<Animator>();
    }

    public void TriggerOpen()
    {
        //Dialogue Manager
        UIanimator.SetBool("open", true);
        UIanimator.SetBool("close", false);
    }

    public void TriggerClose()
    {
        //Dialogue Manager
        UIanimator.SetBool("close",true);
        UIanimator.SetBool("open", false);
    }

}
