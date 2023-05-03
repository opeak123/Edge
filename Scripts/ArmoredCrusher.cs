using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmoredCrusher : MonoBehaviour
{
    public GameObject m_bulletPrefab;
    private Transform m_firePos;

    private Animator m_dustAni;
    private Transform m_crucherTransform;
    private Transform m_playerTransform;
    public bool b_crusherisGround = false;
    public bool b_crusherFloowing = false;
    public bool b_crusherFire = false;
    Coroutine firingCoroutine;

    private void Start()
    {
        m_firePos = gameObject.transform.GetChild(0).gameObject.GetComponent<Transform>();
        m_crucherTransform = transform;
        m_playerTransform = FindObjectOfType<PlayerController>().transform;
        m_dustAni = transform.GetChild(1).GetComponent<Animator>();
    }

    private void Update()
    {
        CrusherTracePlayer();

        if(b_crusherFire)
        {
            CrusherAttack();
        }
    }

    void CrusherTracePlayer()
    {
        Vector2 targetPosition = new Vector2(m_playerTransform.position.x, m_crucherTransform.position.y);
        if (b_crusherisGround && b_crusherFloowing && !DialogueManager.Instance.pb_isTalking)
        {
            m_crucherTransform.position = Vector2.MoveTowards(m_crucherTransform.position,targetPosition, 0.0035f);
        }
    }
    void CrusherAttack()
    {
        if (firingCoroutine == null)
        {
            firingCoroutine = StartCoroutine(FireBullets());
        }
    }

    IEnumerator FireBullets()
    {
        while (true)
        {
            GameObject go = Instantiate(m_bulletPrefab, m_firePos.position, Quaternion.identity);
            Rigidbody2D rb = go.GetComponent<Rigidbody2D>(); // ���� ������ �Ѿ� ������Ʈ�� ���
            rb.velocity = BulletParabola();
            yield return new WaitForSeconds(1f);
            Destroy(go);
        }
    }

    Vector2 BulletParabola()
    {
        float angle = -15f; // �߻簢�� (45��)
        float speed = 6f; // �߻�ӷ� (10 ����Ʈ/��)
        float gravity = Physics2D.gravity.magnitude; // �߷� ���ӵ�

        // x �������δ� ������ �ӷ����� �Ѿ��� ������,
        // y �������δ� �߷� ���ӵ��� ���� ���� �� ������ ���ư����� �����մϴ�.
        float radian = angle * Mathf.Deg2Rad;
        float xSpeed = speed * Mathf.Cos(radian);
        float ySpeed = speed * Mathf.Sin(radian);

        float totalTime = (2f * ySpeed) / gravity;
        float maxHeight = (ySpeed * ySpeed) / (2f * gravity);

        Vector2 velocity = new Vector2(-xSpeed, ySpeed - (gravity * totalTime));

        return velocity;
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "GROUND":
                b_crusherisGround = true;
                transform.GetChild(1).gameObject.SetActive(true);
                RoadManAnimation.FindObjectOfType<RoadManAnimation>().BooleanFly();
                StartCoroutine(SetTime());
                //Destroy(GameObject.Find("TARGET"));
                GameObject.Find("TARGET").gameObject.SetActive(false);

                break;


            default:
                break;
        
        }
    }
    


    IEnumerator SetTime()
    {
        yield return new WaitForSeconds(0.5f);
        transform.GetChild(1).gameObject.SetActive(false);

        yield return new WaitForSeconds(6.7f);
        b_crusherFloowing = true;

        yield return new WaitForSeconds(1f);
        b_crusherFire = true;

    }
}
