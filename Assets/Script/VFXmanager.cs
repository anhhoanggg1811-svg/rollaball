using UnityEngine;

public class VFXmanager : MonoBehaviour
{
    public static VFXmanager Instance{get; private set;}
    [SerializeField] private GameObject pickupVfxPrefab;
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
    public void SpawnPickupVfx(Vector3 position)
    {
        if(pickupVfxPrefab != null)
        {
            Instantiate(pickupVfxPrefab,position,Quaternion.identity);
        }
        else
        {
            Debug.LogWarning("gg");
        }
    }
}
