using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "InputSchema", menuName = "InputSchema")]
public class InputSchema : ScriptableObject
{

    [SerializeField]
    private KeyCode[] leftButtons;
    [SerializeField]
    private KeyCode[] rightButtons;
    [SerializeField]
    private KeyCode[] forwardButtons;
    [SerializeField]
    private KeyCode[] fire1Buttons;
    [SerializeField]
    private KeyCode[] fire2Buttons;
    public bool InputRotateLeft()
    {
        foreach (KeyCode key in leftButtons)
        {
            if( Input.GetKey(key))
            {
                return true;
            }
        }
        return false;
    }

    public bool InputRotateRight()
    {
        foreach (KeyCode key in rightButtons)
        {
            if (Input.GetKey(key))
            {
                return true;
            }
        }
        return false;
    }

    public bool InputForward()
    {
        foreach (KeyCode key in forwardButtons)
        {
            if (Input.GetKey(key))
            {
                return true;
            }
        }
        return false;
    }

    public bool InputFire1()
    {
        foreach (KeyCode key in fire1Buttons)
        {
            if (Input.GetKeyDown(key))
            {
                return true;
            }
        }
        return false;
    }

    public bool InputFire2()
    {
        foreach (KeyCode key in fire2Buttons)
        {
            if (Input.GetKeyDown(key))
            {
                return true;
            }
        }
        return false;
    }

}
