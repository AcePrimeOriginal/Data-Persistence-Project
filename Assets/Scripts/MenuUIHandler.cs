using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUIHandler : MonoBehaviour
{
    // Start is called before the first frame update
    public void StartNew()
    {
        SceneManager.LoadScene(1);
    }

    // Update is called once per frame
    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif 
    }

    public InputField mainInputField;

    public void Start()
    {
        mainInputField.text = "Enter Text Here...";

        //Adds a listener to the main input field and invokes a method when the value changes.
        mainInputField.onValueChanged.AddListener(delegate { ValueChangeCheck(); });

        //Adds a listener that invokes the "LockInput" method when the player finishes editing the main input field.
        //Passes the main input field into the method when "LockInput" is invoked
        mainInputField.onEndEdit.AddListener(delegate { LockInput(mainInputField); });
    }
    // Invoked when the value of the text field changes.
    public void ValueChangeCheck()
    {
        Debug.Log("Value Changed");
    }

    // Checks if there is anything entered into the input field.
    public void LockInput(InputField input)
    {
        if (input.text.Length > 0)
        {
            Debug.Log("Text has been entered");
        }
        else if (input.text.Length == 0)
        {
            Debug.Log("Main Input Empty");
        }
    }
}
