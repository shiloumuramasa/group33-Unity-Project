using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScreenMenu : MonoBehaviour
{
    public GameObject container;
    // Update is called once per frame

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
