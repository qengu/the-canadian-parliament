using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackButton : MonoBehaviour
{

    [SerializeField] private GameObject activate;
    [SerializeField] private GameObject deactivate;

    public void OnButtonClick()
    {
        activate.SetActive(true);
        deactivate.SetActive(false);
    }

}
