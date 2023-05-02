using UnityEngine;

public class NextStage : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("PLAYER"))
        {
            GameManager.Instance.isNextStage = true;
            CameraFollow.FindObjectOfType<CameraFollow>().followTarget = false;
        }
    }
}