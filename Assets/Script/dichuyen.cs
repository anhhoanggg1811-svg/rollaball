using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
public class dichuyen : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private Rigidbody rb;
    private float movementx;
    private float movementy;
    public  float speed=14f;
    private Vector3 startPosition;
    void Start()
    {
        rb=GetComponent<Rigidbody>();
        startPosition = transform.position;
    }

    // Update is called once per frame

    void OnMove(InputValue value)
    {
       Vector2 moveInput =value.Get<Vector2>();
       movementx=moveInput.x;
       movementy=moveInput.y;
    }
     void FixedUpdate()
    {
        Vector3 movement =new Vector3(movementx,0.0f,movementy);
        rb.AddForce(movement*speed);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Goal"))
        {
            Debug.Log("YOU WIN! Bạn đã về đích thành công.");
            if (AudioManager.Instance != null)
            {
                AudioManager.Instance.PlayWinSound();
            }
            SceneManager.LoadScene("winscene");
        }
        if (other.CompareTag("Lose"))
        {
            Debug.Log("Thua.");
            Respawn();
            if (AudioManager.Instance != null)
            {
                AudioManager.Instance.PlayLoseSound();
            }
        }
    }
    public void Respawn()
    {
        transform.position = startPosition;

        if (rb != null)
        {
            rb.linearVelocity = Vector3.zero; 
            rb.angularVelocity = Vector3.zero; 
        }
    }
}
