using UnityEngine;
using UnityEngine.SceneManagement;

public class CarSelection : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
   [SerializeField] GameObject[] cars;
   int currentCarIndex = 0;
   
    void Start()
    {
        Time.timeScale = 1f;
        
        if (cars == null || cars.Length == 0)
        {
            Debug.LogError("[CarSelection] No cars assigned in the Inspector!");
            return;
        }
        
        RemoveNullCars();
        if (cars.Length > 0)
        {
            ShowCar(currentCarIndex);
        }
    }

    public void NextCar()
    {
        if (cars == null || cars.Length == 0)
        {
            Debug.LogWarning("[CarSelection] No cars available!");
            return;
        }

        currentCarIndex++;
        if (currentCarIndex > cars.Length - 1)
        {
            currentCarIndex = 0;
        }
        ShowCar(currentCarIndex);
    }

        public void PreviousCar()
        {
            if (cars == null || cars.Length == 0)
        {
                Debug.LogWarning("[CarSelection] No cars available!");
                return;
        }

            currentCarIndex--;
            if (currentCarIndex < 0)
            {
                currentCarIndex = cars.Length - 1;
            }
            ShowCar(currentCarIndex);
        }

        void RemoveNullCars()
        {
            System.Collections.Generic.List<GameObject> validCars = new System.Collections.Generic.List<GameObject>();
        
            foreach (GameObject car in cars)
            {
                if (car != null)
                {
                    validCars.Add(car);
                }
                else
                {
                    Debug.LogWarning("[CarSelection] Null car reference found and skipped!");
                }
            }
        
            cars = validCars.ToArray();
        }

        void ShowCar(int index)
        {
            if (cars == null || cars.Length == 0)
            {
                Debug.LogError("[CarSelection] Cannot show car - no cars available!");
                return;
            }

            if (index < 0 || index >= cars.Length)
            {
                Debug.LogError("[CarSelection] Invalid car index: " + index);
                return;
            }

            for (int i = 0; i < cars.Length; i++)
            {
                if (cars[i] != null)
                {
                    cars[i].SetActive(i == index);
                }
            }
        }




public void SelectCar()
{
   PlayerPrefs.SetInt("CarIndexValue", currentCarIndex);
}

}




