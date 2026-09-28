using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance{get;private set;}
    [Header("Audio Mixer")]
    [SerializeField] private AudioMixer mainMixer;
    [SerializeField] private AudioSource bgmSource; 
    [SerializeField] private AudioSource sfxSource;
    [SerializeField] private AudioSource winSource;
    [SerializeField] private AudioSource loseSource;
    private bool isSfxEnabled = true;
    public void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            
                Destroy(gameObject);
            
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public bool GetBgmEnabled()
    {
        int isEnabled =PlayerPrefs.GetInt("bgmEnabled", 1);
        return isEnabled == 1;
    }
    public void SetBgmEnabled(bool isEnabled)
    {
        if(bgmSource != null)
        {
            bool isMuted = !isEnabled;
            bgmSource.mute = isMuted;
            PlayerPrefs.SetInt("bgmEnabled",isEnabled ? 1 : 0);
        }
       
    }
    public float GetBgmVolume()
    {
        return PlayerPrefs.GetFloat("bgmVolume", 1f);
    }
    public void ChangeBgmVolume(float volume)
    {
        if(bgmSource !=null)
        {
            bgmSource.volume=volume;
            PlayerPrefs.SetFloat("bgmVolume", volume);
        }
    }
    public bool GetSfxEnabled()
    {
        int isEnabled = PlayerPrefs.GetInt("sfxEnabled", 1);
        return isEnabled == 1;
    }
    public void SetSfxEnabled(bool isEnabled)
    {
        isSfxEnabled = isEnabled;
        if (sfxSource != null)
        {
            sfxSource.mute = !isEnabled;
        }
        PlayerPrefs.SetInt("sfxEnabled", isEnabled ? 1 : 0);
    }
    public float GetSfxVolume()
    {
        return PlayerPrefs.GetFloat("sfxVolume", 1f);
    }
    public void ChangeSfxVolume(float volume)
    {
        PlayerPrefs.SetFloat("sfxVolume", volume);
        if (sfxSource != null)
        {
            sfxSource.volume = volume;
            
        }
        if (winSource != null) 
        {
            winSource.volume = volume;
        }
    
        if (loseSource != null) 
        {
            loseSource.volume = volume;
        }
    }

   

    // 3. Tiếng Win
    public void PlayWinSound()
    {
        if (!isSfxEnabled) return;
        if (winSource != null)
        {
            winSource.PlayOneShot(winSource.clip);
        }
        SetBgmMixerVolume(-60f);
    }

    // 4. Tiếng Lose
    public void PlayLoseSound()
    {
        if (!isSfxEnabled) return;
        if (loseSource != null)
        {
            loseSource.PlayOneShot(loseSource.clip);
        }
        SetBgmMixerVolume(-60f);
    }
    private void SetBgmMixerVolume(float targetDb)
    {
        if (mainMixer != null)
        {
            mainMixer.SetFloat("BGVolume", targetDb);
        }
    }
    public void ResetBgmVolumeToNormal()
    {
        SetBgmMixerVolume(0f); 
    }
}
