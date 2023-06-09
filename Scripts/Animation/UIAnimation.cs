using System;
using UnityEngine;
public class UIAnimation : MonoBehaviour
{
    //UI 애니메이션
    private Animator UIanimator;
    void Start()
    {
        //할당
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
