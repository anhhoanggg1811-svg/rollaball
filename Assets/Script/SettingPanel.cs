using UnityEngine;
using UnityEngine.UI;

public class SettingPanel : MonoBehaviour
{
    [SerializeField] private Toggle bgmToggle;
    [SerializeField] private Slider bgmVolumeSlider;
    [SerializeField] private Toggle sfxToggle;
    [SerializeField] private Slider sfxVolumeSlider;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bgmToggle.onValueChanged.AddListener(OnBgmtoggleChanged);
        bgmVolumeSlider.onValueChanged.AddListener(OnBgmVolumeChanged);
        
        bgmToggle.isOn =AudioManager.Instance.GetBgmEnabled();
        bgmVolumeSlider.value = AudioManager.Instance.GetBgmVolume();
        AudioManager.Instance.ChangeBgmVolume(bgmVolumeSlider.value);
        
        
            sfxToggle.onValueChanged.AddListener(OnSfxToggleChanged);
            sfxVolumeSlider.onValueChanged.AddListener(OnSfxVolumeChanged);
            sfxToggle.isOn = AudioManager.Instance.GetSfxEnabled();
            sfxVolumeSlider.value = AudioManager.Instance.GetSfxVolume(); 
            AudioManager.Instance.ChangeSfxVolume(sfxVolumeSlider.value); 
        
    }
    // Update is called once per frame
    void OnBgmtoggleChanged(bool isOn)
    {
        bool isBgmEnabled = bgmToggle.isOn;
        AudioManager.Instance.SetBgmEnabled(isBgmEnabled);
    }
    void OnBgmVolumeChanged(float volume)
    {
        AudioManager.Instance.ChangeBgmVolume(volume);
    }
    void OnSfxToggleChanged(bool isOn)
    {
        AudioManager.Instance.SetSfxEnabled(isOn);
    }

    void OnSfxVolumeChanged(float volume)
    {
        AudioManager.Instance.ChangeSfxVolume(volume);
    }
}
