using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BottomBarController : MonoBehaviour
{

    [SerializeField] private float scrollSpeed;

    [Header("GUI References")]
    public TextMeshProUGUI barText;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI titleText;
    public Image characterImage;
    public Image sceneBackground;

    public Color playerTextColour;


    public GameScene currentScene;
    public string playerName;

    private int sentenceIndex = 0;
    private State state = State.COMPLETED;

    public void PlayScene(StoryScene scene)
    {
        currentScene = scene;
        if (scene is StoryScene)
        {
            sceneBackground.sprite = (currentScene as StoryScene).background;
        }

        sentenceIndex = -1;
        PlayNextSentence();
    }

    public bool IsCompleted()
    {
        return state == State.COMPLETED;
    }

    public void PlayNextSentence()
    {
        if (currentScene is StoryScene)
        {
            StartCoroutine(TypeText((currentScene as StoryScene).sentences[++sentenceIndex].text));
        }

        Debug.Log(sentenceIndex);
        if ((currentScene as StoryScene).sentences[sentenceIndex].italics)
            barText.fontStyle = FontStyles.Italic;
        else
            barText.fontStyle = FontStyles.Normal;

        Character currentCharacter = (currentScene as StoryScene).sentences[sentenceIndex].character;


        nameText.text = currentCharacter.name;
        nameText.color = currentCharacter.textColour;
        titleText.text = currentCharacter.title;

        int index = (currentScene as StoryScene).sentences[sentenceIndex].iconIndex;
        if (currentCharacter.name == "You")
        {
            characterImage.gameObject.SetActive(false);
            barText.color = playerTextColour;
        }
        else if (currentCharacter.name == "The Chair")
        {
            characterImage.gameObject.SetActive(false);
        }
        else if (index >= 0)
        {
            characterImage.gameObject.SetActive(true);
            characterImage.sprite = currentCharacter.poses[index];
            characterImage.color = Color.white;
            barText.color = Color.white;
        }
        else if (index == -2)
        {
            characterImage.gameObject.SetActive(false);
        }

    }

    public bool IsLastSentence()
    {
        return sentenceIndex + 1 == (currentScene as StoryScene).sentences.Count;
    }

    private enum State
    {
        PLAYING, COMPLETED
    }


    private IEnumerator TypeText(string text)
    {
        barText.text = "";
        state = State.PLAYING;
        int wordIndex = 0;

        while (state != State.COMPLETED)
        {
            if (text[wordIndex] == '>')
                barText.text += playerName;
            else
            {
                barText.text += text[wordIndex];
            }
            yield return new WaitForSeconds(scrollSpeed);
            if (++wordIndex == text.Length)
            {
                state = State.COMPLETED;
                break;
            }
        }

    }

    public void ClearText()
    {
        barText.text = " ";
    }

}
