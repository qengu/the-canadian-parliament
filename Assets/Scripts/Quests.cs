using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Quests : MonoBehaviour
{

    [Header("GUI References")]
    public TextMeshProUGUI mainQuestDescription;
    public TextMeshProUGUI sideQuestDescription;

    [SerializeField] private GameObject billButton;
    public float tweenTime;
    public Image background;

    public Quest[] allQuests;
    public Quest[] allSideQuests;

    public int mainQuestIndex;
    public int sideQuestIndex;
    private bool moving;

    private void Start()
    {
        if (allQuests.Length > 0)
        {
            mainQuestDescription.text = allQuests[0].questDescription;
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

    public void CompleteScene(StoryScene scene)
    {
        if (allQuests.Length > mainQuestIndex && allQuests[mainQuestIndex].requiredScene == scene)
        {
            mainQuestIndex++;
            mainQuestDescription.text = allQuests[mainQuestIndex].questDescription;
            if (mainQuestIndex == 3)
            {
                billButton.SetActive(true);
            }
        }
        if (allSideQuests.Length > sideQuestIndex && allSideQuests[sideQuestIndex].requiredScene == scene)
        {
            sideQuestIndex++;
            sideQuestDescription.text = allSideQuests[sideQuestIndex].questDescription;
        }
    }

    public IEnumerator PauseButton()
    {
        moving = true;
        yield return new WaitForSeconds(tweenTime);
        moving = false;
    }

}
