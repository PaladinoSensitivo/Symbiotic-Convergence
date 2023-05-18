using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyIA : MonoBehaviour
{
    private GameManager _GameManager;
    private Animator anim;
    public int HP;
    public enemyState state;
    private bool isDie;    

    //IA
    private bool isWalk;
    private bool isAlert;
    private bool isAttack;
    private bool isPlayerVisible;
    private NavMeshAgent agent;
    private Vector3 destination;
    private int idWaypoint;

    public QuestGiver quest;
    
    // Start is called before the first frame update
    void Start()
    {
        _GameManager = FindObjectOfType(typeof(GameManager)) as GameManager;
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();

        ChangeState(state);
    }

    // Update is called once per frame
    void Update()
    {
        StateManager();

        if(agent.desiredVelocity.magnitude >= 0.1f)
        {
            isWalk = true;
        }
        else
        {
            isWalk = false;
        }
        anim.SetBool("isWalkEnemy", isWalk);
        anim.SetBool("isAlertEnemy", isAlert);
    }

    IEnumerator Died()
    {
        isDie = true;
        yield return new WaitForSeconds(2.5f);
        Destroy(this.gameObject);
        quest.quest2.goal.EnemyKilled();
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(_GameManager.gameState != GameState.GAMEPLAY) {return;}

        isPlayerVisible = true;
        if(other.gameObject.tag == "Player")
        {
            if(state == enemyState.IDLE || state == enemyState.PATROL)
            {
                ChangeState(enemyState.ALERT);
            }
            else if(state == enemyState.FOLLOW)
            {
                StopCoroutine("FOLLOW");
                ChangeState(enemyState.FOLLOW);
            }            
        }
    }
    private void OnTriggerExit(Collider other) 
    {
        if(other.gameObject.tag == "Player")
        {
            isPlayerVisible = false;
        }
    }

    #region Meus Métodos

    void GetHit(int amount)
    {
        if(isDie == true) { return; }

        HP -= amount;

        if(HP > 0)
        {
            ChangeState(enemyState.FURY);
            anim.SetTrigger("GetHit");
        }
        else
        {
            anim.SetTrigger("Die");
            StartCoroutine("Died");
        }        
    }
    void StateManager()
    {
        if(_GameManager.gameState == GameState.DIE && (state == enemyState.FOLLOW || state == enemyState.FURY || state == enemyState.ALERT))
        {
            ChangeState(enemyState.IDLE);
        }

        switch(state)
        {
            case enemyState.ALERT:
                //LookAt();
                break;
            case enemyState.FOLLOW:
                //Comportamento quando estiver seguindo
                //LookAt();
                destination = _GameManager.player.position;
                agent.destination = destination;
                if(agent.remainingDistance <= agent.stoppingDistance)
                {
                    Attack();
                }
                break;
            case enemyState.FURY:
                //Comportamento quando estiver em fúria
                destination = _GameManager.player.position;
                agent.destination = destination;
                if(agent.remainingDistance <= agent.stoppingDistance)
                {
                    Attack();
                }
                break;
                /*
            case enemyState.PATROL:
                //Comportamento quando esitver patrulhando
                break;
                */
        }
    }
    void ChangeState(enemyState newState)
    {
        StopAllCoroutines(); //Encerra todas as coroutinas para garantia que nenhuma sobreescreva a outra  
        state = newState;
        isAlert = false;

        switch(newState)
        {
            case enemyState.IDLE:  
                agent.stoppingDistance = 0;
                destination = transform.position;
                agent.destination = destination;              
                StartCoroutine("IDLE");
                break;

            case enemyState.ALERT:
                agent.stoppingDistance = 0;
                destination = transform.position;
                agent.destination = destination; 
                isAlert = true;
                StartCoroutine("ALERT");
                break;

            case enemyState.PATROL:
                agent.stoppingDistance = 0;
                idWaypoint = Random.Range(0, _GameManager.slimeWaypoints.Length);
                destination = _GameManager.slimeWaypoints[idWaypoint].position;
                agent.destination = destination;             
                StartCoroutine("PATROL");                
                break;

            case enemyState.FOLLOW:
                agent.stoppingDistance = _GameManager.slimeDistanceToAttack;
                StartCoroutine("FOLLOW");
                break;

            case enemyState.FURY:
                destination = transform.position;
                agent.stoppingDistance = _GameManager.slimeDistanceToAttack;
                agent.destination = destination;

                break;                
            case enemyState.DIE:
                destination = transform.position;
                agent.destination = destination;
                break;
                
        }
        
    }
    IEnumerator IDLE()
    {
        yield return new WaitForSeconds(_GameManager.slimeIdleWaitTime);
        StayStill(50); // 50% de chance de ficar parado ou entrar em patrulha
    }
    IEnumerator PATROL()
    {
        yield return new WaitUntil(() => agent.remainingDistance <= 0);
        StayStill(30); // 30% de chance de ficar parado e 70% de ficar em patrulha
    }
    IEnumerator ALERT()
    {
        yield return new WaitForSeconds(_GameManager.slimeIdleWaitTime);
        if(isPlayerVisible == true)
        {
            ChangeState(enemyState.FOLLOW);
        }
        else
        {
            StayStill(10);
        }
    }
    IEnumerator FOLLOW()
    {
        yield return new WaitUntil(() => !isPlayerVisible);
        yield return new WaitForSeconds(_GameManager.slimeAlertTime);
        StayStill(50);
    }
    IEnumerator ATTACK()
    {
        yield return new WaitForSeconds(_GameManager.slimeAttackDelay);
        isAttack = false;
    }
    int Rand()
    {
        int rand = Random.Range(0, 100); //0 ... 99
        return rand;
    }
    void StayStill(int yes)
    {
        if(Rand() <= yes)
        {
            ChangeState(enemyState.IDLE);
        }
        else // Caso No
        {
            ChangeState(enemyState.PATROL);
        }
    }
    void Attack()
    {
        if(isAttack == false && isPlayerVisible == true)
        {
            isAttack = true;
            anim.SetTrigger("Attack");
        }
    }
    void AttackIsDone()
    {
        StartCoroutine("ATTACK");
    }
    void LookAt()
    {
        Vector3 lookDirection = (_GameManager.player.position = transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(lookDirection);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, _GameManager.slimeLookAtSpeed * Time.deltaTime);
    }

    #endregion
}
