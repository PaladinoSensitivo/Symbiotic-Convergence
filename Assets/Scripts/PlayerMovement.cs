using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    private GameManager _GameManager;
    private CharacterController controller;
    private Animator anim;

    [Header("Config Player")]
    public int HP;
    public float movementSpeed = 3f;
    private Vector3 direction;
    private bool isWalk;

    //Input
    private float horizontal;
    private float vertical;

    [Header("Attack Config")]
    public ParticleSystem fxAttack;
    public Transform hitBox;
    [Range(0.2f, 1f)]
    public float hitRange = 0.5f;
    public Collider[] hitInfo; 
    public LayerMask hitMask;
    private bool isAttack;
    public int amountDMG;

    [Header("Jump Controller")]
    public Transform groundCheck;
    public LayerMask whatIsGround;
    private bool isGrounded;
    public float gravity = -19.63f;
    private Vector3 velocity;

    void Start()
    {
        _GameManager = FindObjectOfType(typeof(GameManager)) as GameManager;
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        if(_GameManager.gameState != GameState.GAMEPLAY) {return;}

        Inputs();

        MoveCharacter();  

        UpdateAnimator(); 
    }
    private void FixedUpdate()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, 0.3f, whatIsGround);
    }
    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.tag == "TakeDamage")
        {
            GetHit(1);
        }
    }

    #region Meus Métodos
    void Inputs()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        if(Input.GetButtonDown("Fire1"))
        {
            Attack();
        }        
    }
    void MoveCharacter()
    {
          

        direction = new Vector3(horizontal, 0f, vertical).normalized;

        if(direction.magnitude > 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, targetAngle, 0);
            isWalk = true;
        }
        else
        {
            isWalk = false;
        }

        controller.Move(direction * movementSpeed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
    void UpdateAnimator()
    {
        anim.SetBool("isWalk", isWalk);
        anim.SetBool("isGrounded", isGrounded);
    }
    void Attack()
    {
        if(!isAttack)
        {
            isAttack = true;
            anim.SetTrigger("Attack");
            fxAttack.Emit(1);

            hitInfo = Physics.OverlapSphere(hitBox.position, hitRange, hitMask);

            foreach(Collider c in hitInfo)
            {
                c.gameObject.SendMessage("GetHit", amountDMG, SendMessageOptions.DontRequireReceiver);        
            }
        }  
    }
    void AttackIsDone()
    {
        isAttack = false;
    }    
    void GetHit(int amount)
    {   
        HP -= amount;
        if(HP > 0)
        {
            anim.SetTrigger("Hit");
        }
        else
        {
            _GameManager.ChangeGameState(GameState.DIE);
            anim.SetTrigger("Die");
        }
    }

    #endregion

    private void OnDrawGizmosSelected()
    {
        if(hitBox != null)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(hitBox.position, hitRange);
        }        
    }
}
