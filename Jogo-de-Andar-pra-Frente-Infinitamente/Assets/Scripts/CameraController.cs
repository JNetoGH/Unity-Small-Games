using UnityEngine;

public class CameraController : MonoBehaviour
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
        Vector3 cameraNewPos = new Vector3(player.transform.position.x, 3, player.transform.position.z - distanceFromPlayerInZ);
        transform.position = cameraNewPos;
    }
}
