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
        UIanimator.SetTrigger("open");
    }

    public void TriggerClose()
    {
        //Dialogue Manager
        UIanimator.SetTrigger("close");
    }
}
