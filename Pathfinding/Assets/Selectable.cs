using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selectable : MonoBehaviour
{
    public object element;
    public void Decide()
    {
        MyInkScript.SetDecision(element);
    }

}