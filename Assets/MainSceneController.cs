using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainSceneController : MonoBehaviour
{
    [SerializeField] private Button startButton;
    [SerializeField] private InputField idInputField;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CheckID()
    {
        if (idInputField.text == string.Empty)
        {
            startButton.interactable = false;
        }
        else
        {
            startButton.interactable = true;
        }

    //    GameManager.Instance.Report.ID = idInputField.text;
    }
}
