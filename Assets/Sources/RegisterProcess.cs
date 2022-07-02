using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegisterProcess : MonoBehaviour
{
    private string _name;

    public void OnNameChanged(string name)
    {
        _name = name;
    }

    public void OnColorValueChanged(Color color)
    {
        
    }

    public void OnSubmit()
    {

    }
}
