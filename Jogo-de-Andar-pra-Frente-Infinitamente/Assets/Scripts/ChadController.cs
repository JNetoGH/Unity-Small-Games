using UnityEngine;

public class ChadController : MonoBehaviour
{
    public int distanceFromPlayerInZ;
    
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 cameraNewPos = new Vector3(transform.position.x, transform.position.y, player.transform.position.z - distanceFromPlayerInZ);
        transform.position = cameraNewPos;
    }
}
