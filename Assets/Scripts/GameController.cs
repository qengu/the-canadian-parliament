using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    public GameScene currentScene;
    public BottomBarController bottomBar;
    public ChooseController chooseController;
    public GameObject houseOfCommons;
    private State state;

    [SerializeField] private GameObject visualGameObject;
    public Quests questsScript;
    [SerializeField] private GameObject chooseScene;

    [SerializeField] private StoryScene fail;
    private PlayerControls playerControls;


    private enum State
    {
        IDLE, ANIMATE, CHOOSE
    }

    private void Awake()
    {
        playerControls = new PlayerControls();
    }

    #region enable disable

    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }

    #endregion

    void Start()
    {

        playerControls.Player.NextSentence.performed += context => NextSentence();

        if (bottomBar.isActiveAndEnabled)
            if (currentScene is StoryScene)
            {
                bottomBar.PlayScene(currentScene as StoryScene);
            }

    }

    private void NextSentence()
    {   

        if (state == State.IDLE && bottomBar.IsCompleted() && visualGameObject.activeSelf)
        {   
            if (bottomBar.IsLastSentence() && currentScene is StoryScene)
            {   
                if (currentScene == fail)
                {
                    SceneManager.LoadScene("StartMenu");
                }
                questsScript.CompleteScene(currentScene as StoryScene);
                if ((currentScene as StoryScene).nextScene != null)
                {   
                    PlayScene((currentScene as StoryScene).nextScene);
                }
                else
                {
                    DeactivateVisualNovelScenes();
                }
            }
            else
            {
                bottomBar.sceneBackground.sprite = (currentScene as StoryScene).background;
                bottomBar.PlayNextSentence();
                houseOfCommons.SetActive(false);
            }
        }
    }

    public void ActivateVisualNovelScenes(StoryScene scene)
    {
        visualGameObject.SetActive(true);
        houseOfCommons.SetActive(false);
        currentScene = scene;
        if (scene is StoryScene)
        {
            bottomBar.sceneBackground.sprite = (currentScene as StoryScene).background;
            bottomBar.PlayScene(currentScene as StoryScene);
        }
    }

    public void DeactivateVisualNovelScenes()
    {
        visualGameObject.SetActive(false);
        houseOfCommons.SetActive(true);
    }

    public void PlayScene(GameScene scene)
    {
        StartCoroutine(SwitchScene(scene));
    }

    private IEnumerator SwitchScene(GameScene scene)
    {

        state = State.ANIMATE;
        currentScene = scene;

        yield return new WaitForSeconds(1f);

        if (scene is StoryScene)
        {
            visualGameObject.SetActive(true);
            StoryScene storyScene = scene as StoryScene;
            bottomBar.sceneBackground.sprite = storyScene.background;
            bottomBar.ClearText();
            bottomBar.PlayScene(storyScene);
            chooseScene.SetActive(false);
            state = State.IDLE;
        }
        else if (scene is ChooseScene)
        {
            chooseScene.SetActive(true);
            chooseController.SetupChoose(scene as ChooseScene);
            visualGameObject.SetActive(false);
        }

    }

}
