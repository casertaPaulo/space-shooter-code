using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreController : MonoBehaviour
{ 
    public int score = 0;
    public static ScoreController instance;
    void Start()
    {
        instance = this;
    }

    void Update()
    {
        
    }

    //Função para adicionar a pontuação
    public void addScore(int points){
        score += points;
    }
}
