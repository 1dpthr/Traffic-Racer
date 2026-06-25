
using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] carsPrefab; 
    [SerializeField] CameraMovement cameraMovement; 
    [SerializeField] Followcar followCar; // This is the slot you'll see in the Inspector
    [SerializeField] UiManager uiManager;
    [SerializeField] Endlesscity[] cityArray;
    [SerializeField] TrafficManager trafficManager;
    [SerializeField] LaneMovement laneMovement;

    void Start()
    {
        SpawnCar();
    }

  

 void SpawnCar()
{
    int currentCarIndex = PlayerPrefs.GetInt("CarIndexValue", 0);
    GameObject newCar = Instantiate(carsPrefab[currentCarIndex], transform.position, transform.rotation);
    
    CarController carController = newCar.GetComponent<CarController>();
    
    // 1. Find the specific Camerapoint object you created in the prefab
    // Note: Use "Camerapoint" with a lowercase 'p' to match your screenshot image_7ae54c
    Transform customCamPoint = newCar.transform.Find("Camerapoint");

    // 2. Pass this point to your Followcar script
    if (followCar != null && customCamPoint != null)
    {
        followCar.SetTarget(newCar.transform, customCamPoint);
    }
    else if (customCamPoint == null)
    {
        Debug.LogWarning("Could not find Camerapoint on the spawned car!");
    }

    // Keep the rest of your working code below
    carController.SetUiManager(uiManager);
    cameraMovement.SetTransform(carController.transform);
    uiManager.SetCarController(carController);
    cityArray[0].SetTransform(carController.transform);
    cityArray[1].SetTransform(carController.transform);
    trafficManager.SetCarController(carController);
    laneMovement.SetTransform(carController.transform);
}
}