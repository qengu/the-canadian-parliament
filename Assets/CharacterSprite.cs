using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSprite : MonoBehaviour
{

    [SerializeField] private Image image;

    private Sprite previousSprite;
    private Sprite sprite;

    private void Start()
    {
        if (image == null)
        {
            image = GetComponent<Image>();
        }
    }

    private void Update()
    {
        sprite = image.sprite;
        if (sprite != previousSprite)
        {
            image.SetNativeSize();
        }
        previousSprite = image.sprite;
    }


}
