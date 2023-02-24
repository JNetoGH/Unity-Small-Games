using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float playerBaseMoveSpeed = 2.25f;
    public float playerBaseRunSpeed = 3.25f;
    private float playerCurrentSpeed;
    private float inputX;
    private float inputY;
    private bool isRunning;
    private bool isMoving;
    private Vector2 newPosition;
    private Rigidbody2D playerRigidBody;
    private Animator playerAnimator;

    void AnimatePlayer()
    {
        // animação de andar
        if (isMoving)
        {
            playerAnimator.SetFloat("inputX", inputX);
            playerAnimator.SetFloat("inputY", inputY);
        }
        playerAnimator.SetBool("isMoving", isMoving);

        // animação de correr
        playerAnimator.SetBool("isRunning", isRunning);

        /*
        // animação de ataque
        if (Input.GetButtonDown("Fire1")) playerAnimator.SetTrigger("attack");*/
    }

    void Start()
    {
        playerCurrentSpeed = playerBaseMoveSpeed; // por padrão usa a valocidade de andar
        isMoving = false; // para ter certeza que a primeira animação será a de idle
        playerRigidBody = GetComponent<Rigidbody2D>(); // pega o Rigidbody do player para movimentar-lo
        playerAnimator = GetComponent<Animator>();   // pega o animator do player pra sincar animação
    }

    void Update()
    {
        // seta as novas posições do player, raw version do metohod só retorna valores absolutos ao contrário da GetAxis() que tbm retorna quebrado 1.4, 23.6, ...
        inputX = Input.GetAxisRaw("Horizontal");
        inputY = Input.GetAxisRaw("Vertical");
        newPosition = new Vector2(inputX, inputY);

        // fica true se receber um input pra se mover entre os eixos
        isMoving = (inputX != 0 || inputY != 0); // fica true se receber um input
        // correr
        isRunning = Input.GetButton("Run");
        playerCurrentSpeed = isRunning ? playerBaseRunSpeed : playerBaseMoveSpeed;

        AnimatePlayer();
    }

    private void FixedUpdate()
    {
        Vector2 currentPosition = this.transform.position;
        playerRigidBody.MovePosition(currentPosition + newPosition * Time.deltaTime * playerCurrentSpeed);
    }

}

