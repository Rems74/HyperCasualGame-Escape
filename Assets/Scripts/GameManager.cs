using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public enum State
    {
        Begining,
        InGame,
        GameOver,
    }


    public State gameState = State.Begining;
    
    void Start()
    {
        gameState = State.InGame;
    }

    public void GameOver()
    {
        
        gameState = State.GameOver;
        
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
