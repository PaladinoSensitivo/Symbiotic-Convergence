using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum enemyState
{
    IDLE, ALERT, PATROL, FOLLOW, FURY, DIE
}
public enum GameState
{
    GAMEPLAY, DIE
}

public class GameManager : MonoBehaviour
{
    public GameState gameState;
    public Transform player;

    [Header("Slime IA")]
    public float slimeIdleWaitTime = 5f;
    public Transform[] slimeWaypoints;
    public float slimeDistanceToAttack = 2.3f;
    public float slimeAlertTime = 3f;
    public float slimeAttackDelay = 1f;
    public float slimeLookAtSpeed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ChangeGameState(GameState newState)
    {
        gameState = newState;
    }
}
