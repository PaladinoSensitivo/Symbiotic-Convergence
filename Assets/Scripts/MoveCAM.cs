using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCAM : MonoBehaviour
{
    [SerializeField]
    private Vector3 offset;

    [Range(0, 1)]
    public float softness = 0.2f;
    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, player.position + offset, softness);
        transform.LookAt(player);
    }
}
