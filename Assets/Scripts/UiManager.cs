using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement; 

public class UiManager : MonoBehaviour
{
    
    [SerializeField] TextMeshProUGUI speedText;
    [SerializeField] TextMeshProUGUI distanceText;

     [SerializeField] TextMeshProUGUI scoreText;

     [SerializeField] TextMeshProUGUI totalScoreText;
     [SerializeField] TextMeshProUGUI totalDistanceText;
    [SerializeField] TextMeshProUGUI maximumSpeedText;


    [SerializeField] CarController carController;
    [SerializeField] Transform carTransform;
    [SerializeField] GameObject gameOverPanel;

    [SerializeField] GameObject speedIcon;
    [SerializeField] GameObject distanceIcon;
    [SerializeField] GameObject scoreIcon;

    private float speed= 0f;
    private float distance= 0f;    
    private float score = 0f;
       private float maximumSpeed = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameOverPanel.SetActive(false);
        speedIcon.SetActive(true);
        distanceIcon.SetActive(true);
        scoreIcon.SetActive(true);
        Time.timeScale=1f;
    }

    // Update is called once per frame
    void Update()
    {
        DistanceUI();
        SpeedUI();
        ScoreUI();
        MaximumSpeed();
  
       
    }
    void DistanceUI()
    {
        distance=carTransform.position.z/1000;
        distanceText.text=distance.ToString("0.00"+"km");
    }
    void SpeedUI()
    {
       speed=carController.CarSpeed();
        speedText.text=speed.ToString("0"+"Km/h");
    }
    void ScoreUI()
    {
     score=carTransform.position.z*6;
     scoreText.text=score.ToString("0");
    }
    public void gameOver()
    {
      Time.timeScale=0f;
      gameOverPanel.SetActive(true);

      speedIcon.SetActive(false);
      distanceIcon.SetActive(false);
      scoreIcon.SetActive(false);

      totalScoreText.text=score.ToString("0");
      totalDistanceText.text=distance.ToString("0.00"+"km");
    }
    void MaximumSpeed()
    {
      float currentSpeed= carController.CarSpeed();
    if(currentSpeed>maximumSpeed)
    {
        maximumSpeed=currentSpeed;

    }
    maximumSpeedText.text=maximumSpeed.ToString("0"+"km/h");
    
    }

    public void TryAgain()
    {
        Time.timeScale = 1f; // MUST add this to unpause the game
        var currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }

    public void MainMenu()
    {
        Debug.Log("[MainMenu] Attempting to load main menu...");
        Time.timeScale = 1f;
        
        try
        {
            if (SceneManager.sceneCountInBuildSettings > 0)
            {
                SceneManager.LoadScene(0);
                Debug.Log("[MainMenu] Successfully loaded scene index 0");
            }
            else
            {
                Debug.LogError("[MainMenu] No scenes in build settings!");
            }
        }
        catch (System.Exception ex)
        {
            Debug.LogError("[MainMenu] Error loading main menu: " + ex.Message);
        }
    }

    public void ReturnToMainMenu()
    {
        MainMenu();
    }

    public void SetCarController(CarController controller)
    {
        carController = controller;
        carTransform = controller != null ? controller.transform : null;
    }
}
