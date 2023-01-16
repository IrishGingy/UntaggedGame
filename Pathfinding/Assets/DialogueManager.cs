using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : GameManager
{
    public void PlayDialogue(string characterName)
    {
        Debug.Log(string.Format("<color=#{0:X2}{1:X2}{2:X2}>{3}</color>", (byte)(Color.green.r * 255f), (byte)(Color.green.g * 255f), (byte)(Color.green.b * 255f), "Playing Ink file..."));
    }
}
