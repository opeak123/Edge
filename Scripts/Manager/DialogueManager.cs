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

    //Image 1��
    public Image m_myImage;
    //Image 2��
    public Image m_yoursImage;
    //�ٲ� �̹��� yours
    public Sprite m_crusherImage;
    //�ٲ� �̹��� mine
    //public Sprite m_mineImage;

    //���ڿ� ����
    [TextArea(3, 8)]
    public string[] m_string;

    //��ȭ������ ���� üũ
    public bool pb_isTalking = false;
    //��ȭ���� ���� ��Ʈ�� Index
    [SerializeField]
    private int m_currentIndex = 0;

    //Canvas �ִϸ��̼�
    private UIAnimation m_uiAni;

    private void Start()
    {
        //�Ҵ�
        m_uiAni= FindObjectOfType<UIAnimation>();

        //String �ʱ�ȭ
        m_textMine.text = "";
        m_textYours.text = "";
    }

    private void Update()
    {
        if(pb_isTalking)
        {
            Talking();
        }
    }

    void Talking()
    {
        m_uiAni.TriggerOpen(); //Dialouge ������ Ȱ��ȭ 
        GameManager.Instance.canMove = false; //��ȭ ���� �� �÷��̾� �ൿ ����
        
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
            //else
            //{
            //    m_uiAni.TriggerClose();
            //    pb_isTalking = false;
            //}
        }
        //string�迭�� text�� �������迭�̶�� �ε����� ó������ ������
        //���� UI�� ���ÿ� ��ȭâ�� ��� ������ �ٲٴ� ����
        //Text�� �ΰ� ��� �������
        if (m_currentIndex == m_string.Length - 1)
        {
            m_currentIndex = 0;       //�ε��� ó������ 
            m_string = new string[0]; //�迭 �ʱ�ȭ
            
            //pb_isTalking = false;
            StartCoroutine(StandbyAction());
            StartCoroutine(UIClose());

            if (GameManager.Instance.currentStageNum == 0) 
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    StageOneInteract();
                }
            }
        }
    }

    //��ȭ�� ������ 2�ʴ�� ���� �ڷ�ƾ ����
    IEnumerator StandbyAction() 
    {
        yield return new WaitForSecondsRealtime(3f);
        pb_isTalking = false;
        GameManager.Instance.canMove = true;
    }
    IEnumerator UIClose()
    {
        yield return new WaitForSeconds(5f);
        UIAnimation.FindObjectOfType<UIAnimation>().TriggerClose();
    }



    //�ִϸ��̼� ��ȣ�ۿ�
    //�� �Լ��� �������� �� ���ӸŴ������� �÷��̾� �̵� ����
    void StageOneInteract()
    {
        PadUpTrigger.FindObjectOfType<PadUpTrigger>().pb_triggerEnd = true;
        ScreenAnimation.FindObjectOfType<ScreenAnimation>().TriggerWarning();
        StartCoroutine(DoorOpenDelay());
    }
    //�ִϸ��̼��� ������ �ڷ�ƾ�� ���� �ִϸ��̼� ��� ����
    IEnumerator DoorOpenDelay()
    {
        DoorAnimation.FindObjectOfType<DoorAnimation>().TriggerDoorOpen();
        yield return new WaitForSeconds(6f);
    }

}    