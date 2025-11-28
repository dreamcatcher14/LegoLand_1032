using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    public GameObject UndoButton;
    public GameObject RedoButton;
    private CommandManager _cmdManager;

    private void Awake()
    {
        _cmdManager = FindObjectOfType<CommandManager>();
    }
    public void UndoButtonOnClick()
    {
        _cmdManager.Undo();
    }
    public void RedoButtonOnClick()
    {
        _cmdManager.Redo(); 
    }
    void Update()
    {
        if (_cmdManager == null) return;
    }
}
