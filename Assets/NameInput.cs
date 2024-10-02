using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NameInput : MonoBehaviour
{

    [SerializeField] private BottomBarController control;
    [SerializeField] private TMP_InputField inputField;

    [SerializeField] private GameObject nameInput;
    [SerializeField] private GameObject VisualNovel;

    public void OnSubmitButtonPress()
    {
        if (inputField.text.Length > 0 && inputField.text.Length <= 12)
        {
            string input = inputField.text;
            VisualNovel.SetActive(true);
            control.playerName = input;
            VisualNovel.SetActive(false);

            nameInput.SetActive(false);
        }
;    }


}
