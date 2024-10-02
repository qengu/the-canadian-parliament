using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseController : MonoBehaviour
{

    public Color defaultColour;
    public Color hoverColour;

    public ChooseLabelController label;
    public GameController gameController;

    private RectTransform rectTransform;
    private float labelHeight = -1f;
    
    public void SetupChoose(ChooseScene scene)
    {
        DestroyLabels();

        for (int i = 0; i < scene.labels.Count; i++)
        {
            ChooseLabelController newLabel = Instantiate(label.gameObject, transform).GetComponent<ChooseLabelController>();
            newLabel.scene = scene.labels[i].nextScene;

            if (labelHeight == -1)
            {
                labelHeight = newLabel.GetHeight();
            }

            newLabel.Setup(scene.labels[i], this, CalculateLabelPosition(i, scene.labels.Count));

        }

    }

    public void PerformChoose(StoryScene scene)
    {
        gameController.PlayScene(scene);
    }

    private float CalculateLabelPosition(int labelIndex, int labelCount)
    {
        if (labelCount % 2 == 0)
        {
            if (labelIndex < labelCount / 2)
            {
                return labelHeight * (labelCount / 2 - labelIndex - 1) + labelHeight / 2;
            }
            else
            {
                return -1 * (labelHeight * (labelIndex - labelCount / 2) + labelHeight / 2);
            }
        }
        else
        {
            if (labelIndex < labelCount / 2)
            {
                return labelHeight * (labelCount / 2 - labelIndex);
            }
            else if (labelIndex > labelCount / 2)
            {
                return -1 * labelHeight * (labelIndex - labelCount / 2);
            }
            else
            {
                return 0;
            }
        }
    }

    private void DestroyLabels()
    {
        foreach(Transform childTransform in transform)
        {
            Destroy(childTransform.gameObject);
        }
    }

}
