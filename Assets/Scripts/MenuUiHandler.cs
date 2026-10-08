using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif


public class MenuUiHandler : MonoBehaviour

{
    [SerializeField] private TMP_InputField myInputField;
    [SerializeField] private EncapsulatedStringSO textContainer; // ENCAPSULATION USING SCRIPTABLE OBJECTS
   


    public void Exit()
    {

#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif
    }

    public void StartNew()
    {
        textContainer.UserInputText = myInputField.text; // ENCAPSULATION USING SCRIPTABLE OBJECTS
        SceneManager.LoadScene(1);
    }

}


