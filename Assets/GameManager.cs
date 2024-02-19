using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] public static float currentCheckpoint;
  
    [SerializeField] GameObject gameOverMenu;
    [SerializeField] GameObject princess;
    private void OnEnable()
    {
        GuardController.OnCaught += EnableGameOverMenu;
    }

    private void OnDisable()
    {
        GuardController.OnCaught -= EnableGameOverMenu;
    }

    private void Start()
    {
        princess.transform.position =  new Vector3(currentCheckpoint, 6.9f, 0f);
    }
  
    public void EnableGameOverMenu()
    {
        //disable character movement
        gameOverMenu.SetActive(true);
    }

    public void UpdateCheckpoint(float checkpoint){
        currentCheckpoint = checkpoint;
        Debug.Log(currentCheckpoint);
    }

    public void Retry(){
        SceneManager.LoadScene(0);
    }
}
