using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameStateManager : MonoBehaviour
{
    public static GameStateManager Instance; 

    [HideInInspector]
    public int sheepSaved;

    [HideInInspector]
    public int sheepDropped;

    public int sheepDroppedBeforeGameOver;
    public SheepSpawner sheepSpawner;

    void Awake()
    {
        Instance = this;
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Title");
        }

    }

    public void SavedSheep()
    {
        UIManager.Instance.UpdateSheepSaved();

        sheepSaved++;
    }

    private void GameOver()
    {
        UIManager.Instance.ShowGameOverWindow();

        sheepSpawner.canSpawn = false; 
        sheepSpawner.DestroyAllSheep(); 
    }

    public void DroppedSheep()
    {
        sheepDropped++;
        UIManager.Instance.UpdateSheepDropped();


        if (sheepDropped == sheepDroppedBeforeGameOver) 
        {
            GameOver();
        }
    }



}
