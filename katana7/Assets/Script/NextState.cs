using UnityEngine;
using UnityEngine.SceneManagement;

public class NextState : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //다음씬으로전환
            SceneManager.LoadScene("Boss");

        }
    }
}
