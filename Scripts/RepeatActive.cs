using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatActive : MonoBehaviour
{
    //������Ʈ Ȱ��ȭ �ð� 
    [SerializeField]
    private float activeTime = 1f;

    //�ð� üũ 
    [SerializeField]
    private float timer = 0f;

    //������Ʈ �ڽ� SpriteRenderer
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        //�Ҵ�
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        Repeat();
    }

    void Repeat()
    {
        //�ð�üũ
        timer += Time.deltaTime;

        if (timer >= activeTime)
        {   
            //�ð� �ʱ�ȭ
            //������Ʈ�� Ȱ��ȭ ������ ��Ȱ��ȭ
            //��Ȱ��ȭ �ƴٸ� Ȱ��ȭ
            spriteRenderer.enabled = !spriteRenderer.enabled; 
            timer = 0f;
        }
    }
}








