using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.EventSystems;

public class QuestButton : MonoBehaviour, IPointerClickHandler
{

    [SerializeField] private Image buttonImage;
    [SerializeField] private Sprite offSprite;
    [SerializeField] private Sprite onSprite;

    [SerializeField] private Quests questsScript;

    public float tweenTime;
    public Image background;

    private bool moving;

    private bool questMenuOpen;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (moving == false)
        {
            questMenuOpen = !questMenuOpen;
            buttonImage.sprite = questMenuOpen ? onSprite : offSprite;
        }

        if (questMenuOpen)
        {
            OpenQuestMenu();
        }
        else
        {
            CloseQuestMenu();
        }

    }

    public void OpenQuestMenu()
    {
        if (moving == false)
        {
            LeanTween.moveLocalX(background.gameObject, -311f, tweenTime).setEaseInOutQuart();
            StartCoroutine(PauseButton());
        }
    }

    public void CloseQuestMenu()
    {
        if (moving == false)
        {
            LeanTween.moveLocalX(background.gameObject, -495f, tweenTime).setEaseOutQuart();
            StartCoroutine(PauseButton());
        }
    }

    public IEnumerator PauseButton()
    {
        moving = true;
        yield return new WaitForSeconds(tweenTime);
        moving = false;
    }

}
