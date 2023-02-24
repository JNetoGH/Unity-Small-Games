using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed;
    private Animator animator;
    private Rigidbody rgbd;
    private bool _isMoving;
    

    // Start is called before the first frame update
    void Start()
    {
        rgbd = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        _isMoving = Input.anyKey;
        animator.SetBool("IsMoving", _isMoving);
    }


    // Physics: 50fps
    private void FixedUpdate()
    {
        if (_isMoving) 
            rgbd.MovePosition(rgbd.position + Vector3.forward * speed * Time.deltaTime);
    }
}