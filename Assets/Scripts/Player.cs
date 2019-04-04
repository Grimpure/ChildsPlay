using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public enum colours { Purple, Yellow, Blue, Red }

    // Start is called before the first frame update
    void Start()
    {
        //colours npc = (colours)Random.Range(0, 5);
        colours playerColour = (colours)colours.ToObject(typeof(colours), Random.Range(0, 5));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
