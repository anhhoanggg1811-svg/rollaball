using UnityEngine;

public class Settinggroup : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject settingGroup; // Kéo SettingGroup vào đây trong Inspector

    
    public void ToggleSettingUI()
    {
        if (settingGroup != null)
        {
            
            bool isActive = settingGroup.activeSelf;
            settingGroup.SetActive(!isActive);
        }
    }
}
