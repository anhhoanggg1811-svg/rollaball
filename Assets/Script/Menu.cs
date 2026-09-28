using UnityEngine;
using UnityEngine.SceneManagement;
public class Menu : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void PlayGame()
    {
        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.ResetBgmVolumeToNormal();
        }
        SceneManager.LoadScene("SampleScene");
    }
    public void BackMenu()

    {

        SceneManager.LoadScene("menu");

    }
}
