using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rextart : MonoBehaviour
{
    private InputControls inputActions;
    // Start is called before the first frame update
    void Start()
    {
        inputActions = new InputControls();
    }


    // Update is called once per frame
    void Update()
    {
        if (inputActions.Input.Restart.IsPressed())
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }
    }
}
