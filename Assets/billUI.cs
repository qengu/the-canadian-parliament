using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class billUI : MonoBehaviour
{


    [SerializeField] private GameObject Bill;

    public void OnButtonPress()
    {
        Bill.SetActive(!Bill.activeSelf);
    }

}
