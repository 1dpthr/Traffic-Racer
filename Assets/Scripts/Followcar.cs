using UnityEngine;

public class Followcar : MonoBehaviour
{
    public Transform carTransform;
    public Transform cameraPointtransforn;
    private Vector3 velocity=Vector3.zero;

    public void SetTarget(Transform car, Transform cameraPoint)
    {
        carTransform = car;
        cameraPointtransforn = cameraPoint;
    }
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (carTransform == null || cameraPointtransforn == null)
        {
            return;
        }

        transform.LookAt(carTransform);
        transform.position=Vector3.SmoothDamp(transform.position,cameraPointtransforn.position,ref velocity,5f*Time.deltaTime);
        
    
    }
}
