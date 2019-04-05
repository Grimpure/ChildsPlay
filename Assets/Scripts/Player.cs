using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    public Text assignedColour;

    public enum colours { Purple, Yellow, Blue, Red }

    // Start is called before the first frame update
    void Start()
    {
        //colours npc = (colours)Random.Range(0, 5);
        colours playerColour = (colours)colours.ToObject(typeof(colours), Random.Range(0, 5));

        switch (playerColour) // Sometimes numbers will pop up in the enum
        {
            case colours.Purple:
                assignedColour.text = "Your colour is purple";
                break;
            case colours.Red:
                assignedColour.text = "Your colour is red";
                break;
            case colours.Yellow:
                assignedColour.text = "Your colour is yellow";
                break;
            case colours.Blue:
                assignedColour.text = "Your colour is blue";
                break;
            default: // if anything else but the 4 colours shows up, then this will make sure that it will reset the choosing process and make sure the AI gets an colour assigned
                Start();
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
