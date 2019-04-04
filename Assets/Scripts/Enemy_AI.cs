using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy_AI : MonoBehaviour
{

    public Transform[] targets;

    public Transform follow;

    Vector3 targetCord;

    public Vector3 usualSpot;

    public bool timeToAttack;

    NavMeshAgent thisHunter;
    
    // Start is called before the first frame update
    void Start()
    {
        thisHunter = this.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (timeToAttack)
        {
            case true:
                follow = targets[Random.Range(0, 5)];
                targetCord = follow.position;
                thisHunter.SetDestination(targetCord);
                break;
            case false:
                thisHunter.SetDestination(usualSpot);
                break;
        }

    }
}
