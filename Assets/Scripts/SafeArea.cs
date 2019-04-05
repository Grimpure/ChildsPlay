using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeArea : MonoBehaviour
{

    public int thisLine;

    NPC_AI allyNPC;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Ally")
        {
            allyNPC = other.gameObject.GetComponent<NPC_AI>();

            if (allyNPC.currentLine == thisLine)
            {
                allyNPC.safe = true;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        switch(other.gameObject.tag)
        {
            case "Ally":
                allyNPC = other.gameObject.GetComponent<NPC_AI>();
                allyNPC.safe = false;
                break;
        }
    }
}
