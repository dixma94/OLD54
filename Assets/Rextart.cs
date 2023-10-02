using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Rextart : MonoBehaviour
{
    private InputControls inputActions;
    [SerializeField] private GameObject GameOverPanel;
    [SerializeField] private GameObject WinPanel;
    [SerializeField] private RisingWater risingWater;

    // Start is called before the first frame update
    void Start()
    {
        GameOverPanel.SetActive(false);
        WinPanel.SetActive(false);
        inputActions = new InputControls();
        inputActions.Input.Enable();
        EntityManager.Instance.TargetKilled += Instance_TargetKilled;
        risingWater.Water += RisingWater_Water;
    }

    private void RisingWater_Water()
    {
        Win();
    }

    private void Instance_TargetKilled(Targettable target)
    {
        if (target.targetType == EntityType.Hero || target.targetType == EntityType.Factory)
        {
            gameOver();
        }
    }

    private void gameOver()
    {
        GameOverPanel.SetActive(true);
        Time.timeScale = 0;
    }
    private void Win()
    {
        WinPanel.SetActive(true);
        Time.timeScale = 0;
    }


    // Update is called once per frame
    void Update()
    {
        if (inputActions.Input.Restart.IsPressed())
        {
            Time.timeScale = 1f;
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);

        }
    }
}
