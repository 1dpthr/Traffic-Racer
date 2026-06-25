using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    
    [SerializeField] private Transform playerCarTransform;
    // [SerializeField] private Transform otherCityTransform;
    [SerializeField] private float offset= -05;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void  LateUpdate()
    {
       if (playerCarTransform == null)
       {
           return;
       }
        
Vector3 cameraPos=transform.position;
       cameraPos.z=playerCarTransform.position.z+offset;
       transform.position=cameraPos;


    }

    public void SetTransform(Transform target)
    {
        playerCarTransform = target;
    }
}


  