using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "New Quest", menuName = "Story/Quest")]
public class Quest : ScriptableObject
{

    public string questDescription;
    public StoryScene requiredScene;

}
