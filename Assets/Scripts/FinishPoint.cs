
using UnityEngine;

public class FinishPoint : MonoBehaviour
{
    public GameObject winScreen;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Something touched the finish point!");

        if (other.GetComponent<PlayerController>() != null)
        {
            Debug.Log("Player reached the finish!");

            winScreen.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
