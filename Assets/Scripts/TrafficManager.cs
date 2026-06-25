using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficManager : MonoBehaviour
{
    // These names must match what you use below
    [SerializeField] Transform[] lane;
    [SerializeField] GameObject[] trafficVehicle;
    [SerializeField] CarController carController;
     [SerializeField] float minSpawnTime= 30f;
         [SerializeField] float MaxSpawnTime= 60f;
     private float dynamicTimer= 2f;


    void Start()
    {
        StartCoroutine(TrafficSpawner());
    }

    IEnumerator TrafficSpawner()
    {
        yield return new WaitForSeconds(3f);
        while(true)
        {
            // int randomLaneIndex = Random.Range(0, lane.Length);
            // int randomTrafficVehicleIndex = Random.Range(0, trafficVehicle.Length);

            // // FIXED: Removed the 's' from 'trafficVehicles' and 'lanes' to match the variables above
            // Instantiate(trafficVehicle[randomTrafficVehicleIndex], lane[randomLaneIndex].position, Quaternion.identity);
            if(carController.CarSpeed()>10f)
            {
                dynamicTimer=Random.Range(minSpawnTime,MaxSpawnTime)/ carController.CarSpeed();

                spawnTrafficVehicle();
            }
            yield return new WaitForSeconds(dynamicTimer);
        }
    }
    void spawnTrafficVehicle()

    {
        int randomLaneIndex = Random.Range(0, lane.Length);
            int randomTrafficVehicleIndex = Random.Range(0, trafficVehicle.Length);

            // FIXED: Removed the 's' from 'trafficVehicles' and 'lanes' to match the variables above
            Instantiate(trafficVehicle[randomTrafficVehicleIndex], lane[randomLaneIndex].position, Quaternion.identity);
    }

    public void SetCarController(CarController controller)
    {
        carController = controller;
    }
}
