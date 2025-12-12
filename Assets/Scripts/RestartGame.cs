using Unity.VisualScripting;
using UnityEngine;

public class RestartGame : MonoBehaviour
{
    public void LoadCurrentScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("SillyGuy");
        Time.timeScale = 1.0f;
    }
}
