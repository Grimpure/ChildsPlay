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

    EmptyCheck isDestEmpty;

    public Material red;
    public Material blue;
    public Material purple;
    public Material yellow;

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

        switch (npcColour) // Sometimes numbers will pop up in the enum
        {
            case colours.Purple:
                this.GetComponent<Renderer>().material = purple;
                break;
            case colours.Red:
                this.GetComponent<Renderer>().material = red;
                break;
            case colours.Blue:
                this.GetComponent<Renderer>().material = blue;
                break;
            case colours.Yellow:
                this.GetComponent<Renderer>().material = yellow;
                break;
            default: // if anything else but the 4 colours shows up, then this will make sure that it will reset the choosing process and make sure the AI gets an colour assigned
                Start();
                break;
        }
        isDestEmpty = dest.GetComponent<EmptyCheck>();

        thisNPC = this.GetComponent<NavMeshAgent>();
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
    void goForward() // check works partly, in rare events 2 npc's will still stand at the same spot. 
    {
        currentLine++;

        switch (currentLine)
        {
            case 0: //Begin Destination
                // Not sure if this will be used
                break;
            case 1:
                isDestEmpty.isTaken = false;
                dest = Destination1[Random.Range(0,5)];
                isDestEmpty = dest.GetComponent<EmptyCheck>();
                break;
            case 2:
                isDestEmpty.isTaken = false;
                dest = Destination2[Random.Range(0, 5)];
                isDestEmpty = dest.GetComponent<EmptyCheck>();
                break;
            case 3:
                isDestEmpty.isTaken = false;
                dest = Destination3[Random.Range(0, 5)];
                isDestEmpty = dest.GetComponent<EmptyCheck>();
                break;
            case 4: //End Destination
                isDestEmpty.isTaken = false;
                dest = endDestination[Random.Range(0, 5)];
                isDestEmpty = dest.GetComponent<EmptyCheck>();
                break;
            default: // because of LINE 112 - LINE 115 I made a check that the int CurrentLine will never go below 0.
                currentLine = 0;
                break;
        }

        switch(isDestEmpty.isTaken)
        {
            case true:
                currentLine--;
                goForward();
                break;
            case false:
                isDestEmpty.isTaken = true;
                break;

        }

        stayOnPlace = true; // automatically resets the bool so the action won't repeat itself untill it is supposed to.
    }
}
