using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy_AI : MonoBehaviour
{

    GameManager GM;

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
        GM = GameObject.Find("Manager_Tracker").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        thisHunter.SetDestination(targetCord);
        targetCord = follow.position;
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
        if(!follow.gameObject.activeInHierarchy == true)
        {
            target();
        }
        else
        {
            thisHunter.speed += 5;
            thisHunter.acceleration += 10;
            thisHunter.angularSpeed += 20;
        }
        StartCoroutine(GM.HuntUp());
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            
        }
    }

}
