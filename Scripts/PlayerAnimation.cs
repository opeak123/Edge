using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimation : MonoBehaviour
{
    //�÷��̾� �ִϸ��̼�
    private Animator animator;
    private void Awake()
    {
        //�Ҵ�
        animator = GetComponent<Animator>();
    }

    public void SetIsGrounded(bool isGrounded) //idle �ִϸ��̼�
    {
        animator.SetBool("idle", isGrounded);
    }

    public void SetSpeed(float speed)   //walk �ִϸ��̼�
    {
        animator.SetFloat("speed", speed);
    }

    public void TriggerJump()   //jump �ִϸ��̼�
    {
        animator.SetTrigger("jump");
    }

    public void TriggerDash() //dash �ִϸ��̼�
    {
        animator.SetTrigger("dash");
    }
    public void TriggerCrouch() //crouch �ִϸ��̼�
    {
        animator.SetTrigger("crouch");
    }
    public void TriggerSleep() //sleep �ִϸ��̼�
    {
        animator.SetBool("sleep", true);
    }

    public void TriggerWakeUp() //wake up �ִϸ��̼�
    {
        animator.SetBool("wakeUp", true);
    }
    public void TriggerLookingUp() // looking up �ִϸ��̼�
    {
        animator.SetTrigger("lookingUp");
    }
    public void BooleanLaddering(bool value) //laddering �ִϸ��̼�
    {
        animator.SetBool("laddering",true);
    }
}