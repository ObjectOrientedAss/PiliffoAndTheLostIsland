using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameManager : MonoBehaviour
{
    public GameObject Player;

    float counter = 5;
    void Update()
    {
        Player.gameObject.GetComponent<Animator>().SetBool("death", true);
        counter -= Time.deltaTime;
        if (counter <= 0)
        {
            GameEventSystem.LoseGame();
        }
    }
}
