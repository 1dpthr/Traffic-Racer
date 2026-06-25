using UnityEngine;

public class Destroyoncontect : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
private void OnTriggerEnter(Collider other)
{
    // FIXED: Use lowercase 'g'
    Destroy(other.transform.parent. gameObject);
}
  
}
