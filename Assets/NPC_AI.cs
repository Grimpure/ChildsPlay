using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPC_AI : MonoBehaviour
{
    public Vector3 dest_cord;

    public Transform dest;

    public int currentLine = 0;

    public bool stayOnPlace = true;

    public Transform[] startDestination;
    public Transform[] Destination1;
    public Transform[] Destination2;
    public Transform[] Destination3;
    public Transform[] endDestination;



    NavMeshAgent thisNPC;

    public enum colours {Purple, Yellow, Blue, Red }

    // Start is called before the first frame update
    void Start()
    {
        colours npcColour = (colours)colours.ToObject(typeof(colours), Random.Range(0, 5));
        thisNPC = this.GetComponent<NavMeshAgent>();
        Debug.Log(npcColour); // REMOVE WHEN DONE
    }

    // Update is called once per frame
    void Update()
    {
        dest_cord = dest.position;
        thisNPC.SetDestination(dest_cord);

        switch (stayOnPlace)
        {
            case false:
                goForward();
                break;
            case true:
                //No action required
                break;
        }

    }
    void goForward()
    {
        currentLine++;

        switch (currentLine)
        {
            case 0: //Begin Destination
                // Not sure if this will be used
                break;
            case 1:
                dest = Destination1[Random.Range(0,5)];
                break;
            case 2:
                dest = Destination2[Random.Range(0, 5)];
                break;
            case 3:
                dest = Destination3[Random.Range(0, 5)];
                break;
            case 4: //End Destination
                dest = endDestination[Random.Range(0, 5)];
                break;
        }


        stayOnPlace = true; // automatically resets the bool so the action won't repeat itself untill it is supposed to.
    }
}
