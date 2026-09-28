using UnityEngine;

public class coincontroller : MonoBehaviour
{

    public GameObject coinPrefab;
    public float rangeX=8f;
    public float rangeZ=8f;
    public float rangeY=0.7f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            ScoreManager.instance.AddScore(1);
            Destroy(gameObject);
            Vector3 pickupPosition = other.gameObject.transform.position;
            VFXmanager.Instance.SpawnPickupVfx(pickupPosition);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
