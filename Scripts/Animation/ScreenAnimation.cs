using UnityEngine;

public class ScreenAnimation : MonoBehaviour
{
    //��ũ�� �ִϸ��̼� 
    Animator m_ani;
    void Start()
    {
        //�Ҵ�
        m_ani = GetComponent<Animator>();
    }
    public void TriggerMove()
    {
        //��ũ���� move �ִϸ��̼� Ȱ��ȭ�ƴٸ� order�� �ڷ�
        m_ani.SetTrigger("move");
        GetComponentInChildren<SpriteRenderer>().sortingOrder = -1;
    }
    public void TriggerWarning()
    {
        //��ũ���� warning �ִϸ��̼� Ȱ��ȭ�ƴٸ� order�� ������
        m_ani.SetTrigger("warning");
        GetComponentInChildren<SpriteRenderer>().sortingOrder = 2;
    }


}
