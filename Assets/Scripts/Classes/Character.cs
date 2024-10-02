using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
[CreateAssetMenu(fileName = "New Character", menuName = "Story/Character")]
public class Character : ScriptableObject
{

    public new string name;
    public string title;
    public Color textColour;
    public Sprite[] poses;

}
