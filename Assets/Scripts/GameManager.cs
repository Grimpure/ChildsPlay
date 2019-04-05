using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    NPC_AI ally;
    Enemy_AI hunter;

    public float timerAttack = 10;

    bool goTimer;

    public Text timerDisplay;

    // Start is called before the first frame update
    void Start()
    {
        ally = GetComponent<NPC_AI>();
        hunter = GameObject.Find("Enemy").GetComponent<Enemy_AI>();
    }

    // Update is called once per frame
    void Update()
    {
        timerDisplay.text = timerAttack.ToString();
        switch(goTimer)
        {
            case true:
                timerAttack -= 1 * Time.deltaTime;
                break;
        }
    }
    public IEnumerator HuntUp()
    {
        goTimer = true;
        yield return new WaitForSeconds(timerAttack);

        hunter.follow = hunter.usualSpot;
        goTimer = false;
        timerAttack = 10;
    }
}
