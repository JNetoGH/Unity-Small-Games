using UnityEngine;

public class BumpController : MonoBehaviour
{
    public GameObject NextStreetPrefab;
    private void OnTriggerExit(Collider other)
    {
        
        
        if (gameObject.tag.Equals("bumpOUT"))
            Destroy(transform.parent.gameObject);
        else if (gameObject.tag.Equals("bumpIN"))
        {
            GameObject instantiated = Instantiate(NextStreetPrefab);
            instantiated.transform.position = new Vector3(instantiated.transform.position.x, instantiated.transform.position.y, instantiated.transform.position.z +140);
        }
            
    } 
}
