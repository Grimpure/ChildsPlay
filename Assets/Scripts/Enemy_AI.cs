using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy_AI : MonoBehaviour
{

    public Transform[] targets;

    public Transform follow;

    Vector3 targetCord;

    public Transform usualSpot;

    public bool timeToAttack;

    public NavMeshAgent thisHunter;

    NPC_AI targetScript;
    
    // Start is called before the first frame update
    void Start()
    {
        thisHunter = this.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {

        targetScript = follow.GetComponent<NPC_AI>();

        switch (timeToAttack)
        {
            case true:
                target();
                timeToAttack = false;
                break;
            case false:
                //nothing
                break;
        }
    }
    void target()
    {
        follow = targets[Random.Range(0, 5)];
        if(targetScript.gameObject.activeInHierarchy == false)
        {
            target();
        }
        else
        {
            thisHunter.speed += 5;
        }

        targetCord = follow.position;
        thisHunter.SetDestination(targetCord);

        float timer = 0;
        timer += Time.deltaTime;
        if(timer > 10)
        {
            thisHunter.SetDestination(usualSpot.position);
        }
    }
}
