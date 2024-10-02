using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Hover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{

    [SerializeField] private GameController controllerScript;
    [SerializeField] private int order;
    [SerializeField] private StoryScene duplicatedOffice;

    public Texture2D cursorArrow; 
    public StoryScene scene;
    public StoryScene alternateScene;

    public void OnPointerEnter(PointerEventData eventData)
    {
        //cursorArrow.alphaIsTransparency = true;
        Cursor.SetCursor(cursorArrow, new Vector2(16f, 16f), CursorMode.ForceSoftware);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.ForceSoftware);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (controllerScript.questsScript.mainQuestIndex == 7 && duplicatedOffice != null)
        {
            scene = duplicatedOffice;
            order = 7;
        }
        if (order == controllerScript.questsScript.mainQuestIndex) 
        {
            controllerScript.ActivateVisualNovelScenes(scene);
        }
        else
        {
            if (alternateScene != null)
            {
                controllerScript.ActivateVisualNovelScenes(alternateScene);
            }
        }
        Cursor.SetCursor(null, Vector2.zero, CursorMode.ForceSoftware);
    }
}
