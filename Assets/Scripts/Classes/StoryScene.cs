using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "New Story Scene", menuName = "Story/Story Scene")]
public class StoryScene : GameScene
{

    public List<Sentence> sentences;
    public Sprite background;
    public GameScene nextScene;

    [System.Serializable]
    public struct Sentence
    {
        public string text;
        public Character character;
        public int iconIndex;
        public bool italics;
    }

}

public class GameScene : ScriptableObject
{

}
