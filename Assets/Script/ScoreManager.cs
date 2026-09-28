using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public int score =0;
    public TextMeshProUGUI scoreText;
    [Header("Win Settings")]
    public int targetScore = 5; // Số lượng coin cần đạt để thắng (có thể chỉnh trong Inspector)
    private bool hasWon = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "menu")
    {
        scoreText.gameObject.SetActive(false); // Ẩn Score ở menu
    }
    else
    {
        scoreText.gameObject.SetActive(true);  // Hiện Score ở gameplay
    }
    }
    void Awake()
    {
        instance=this;
    }
    public void AddScore(int points)
    {
        if (hasWon) return;
        score+=points;
        scoreText.text ="Score: "+score;
        
    }
    void Update()
    {
        
    }
    
}
