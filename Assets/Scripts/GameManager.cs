using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public float initialGameSpeed = 5f;
    public float gameSpeedIncrease =  0.1f;
    public float MinSpeed = 2f;
    public float gameSpeed { get; private set; }

    private void Awake()
    {   
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            DestroyImmediate(gameObject);
        }
    }

    private void OnDestroy()
    {
        if (Instance == this)
        {
            Instance = null;
        }
    }

    private void Start()
    {
        
    }

    private void NewGame()
    {
        gameSpeed = initialGameSpeed;
    }

    private void Update()
    {
        gameSpeed += gameSpeedIncrease * Time.deltaTime;
        gameSpeed = Mathf.Clamp(gameSpeed, MinSpeed , 18);
        
        if(gameSpeed > 6f)
        {
            gameSpeedIncrease = 0.1f;
        }
    }
}
