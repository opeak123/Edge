using System.Collections;
using System;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    //DialogueManager �ν��Ͻ� ����
    public static DialogueManager Instance;

    void Awake()
    {
        if (Instance == null)
            Instance = this;

        else if (Instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    //Text 1��
    public Text m_textMine; 
    //Text 2��
    public Text m_textYours;

    //���ڿ� ����
    [TextArea(3, 8)]
    public string[] m_string;

    //��ȭ������ ���� üũ
    public bool isTalking = false;
    //��ȭ���� ���� ��Ʈ�� Index
    private int m_currentIndex = 0;

    private void Start()
    {
        //String �ʱ�ȭ
        m_textMine.text = "";
        m_textYours.text = "";
    }

    private void Update()
    {
        if(isTalking)
          Talking();
    }

    void Talking()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //currentIndex �� string �迭�� ũ�⺸�� �۴ٸ�
            if (m_currentIndex < m_string.Length)
            {
                //Text �θ��� �ڽ�
                //���� ��ȭâ�� UI�� Order in Layer ������ �ٲ۴�
                if (m_currentIndex % 2 == 0)
                {
                    m_textYours.transform.parent.SetSiblingIndex(2);
                    m_textMine.text = m_string[m_currentIndex];
                    m_textYours.text = "";
                }
                else
                {
                    m_textMine.transform.parent.SetSiblingIndex(2);
                    m_textYours.text = m_string[m_currentIndex];
                    m_textMine.text = "";
                }
                m_currentIndex++;
            }
            else
            {
                isTalking = false;
            }
        }
        //string�迭�� text�� 6��°��� �ε����� ó������ ������
        //���� UI�� ���ÿ� ��ȭâ�� ��� ������ �ٲٴ� ����
        //(Text �Ѵ� �������)
        if(m_currentIndex == 6) 
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Interact();
                m_currentIndex++;
            }
        }
    }

    //�ִϸ��̼� ��ȣ�ۿ�
    //�� �Լ��� �������� �� ���ӸŴ������� �÷��̾� �̵� ����
    void Interact()
    {
        PadUpTrigger.FindObjectOfType<PadUpTrigger>().pb_triggerEnd = true;
        ScreenAnimation.FindObjectOfType<ScreenAnimation>().TriggerWarning();
        StartCoroutine(TriggerDoorOpenWithDelay(3f));
        GameManager.Instance.canMove = true;
    }

    //�ִϸ��̼��� ������ �ڷ�ƾ�� ���� �ִϸ��̼� ��� ����
    IEnumerator TriggerDoorOpenWithDelay(float delay)
    {
        UIAnimation.FindObjectOfType<UIAnimation>().TriggerClose();
        yield return new WaitForSeconds(delay);

        DoorAnimation.FindObjectOfType<DoorAnimation>().TriggerDoorOpen();
        yield return new WaitForSeconds(delay+delay);
    }
}    