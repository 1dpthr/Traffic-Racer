using UnityEngine;

public class Endlesscity : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    [SerializeField] private Transform playerCarTransform;
    [SerializeField] private Transform otherCityTransform;
    [SerializeField] private float halfLength;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerCarTransform == null || otherCityTransform == null)
        {
            return;
        }

        if (playerCarTransform.position.z > transform.position.z + halfLength + 10f) 
        {
            transform.position=new Vector3(0,0,otherCityTransform.position.z+halfLength*2);
        }
    }

    public void SetTransform(Transform target)
    {
        playerCarTransform = target;
    }
}
