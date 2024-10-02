using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlackScreen : MonoBehaviour
{

    [SerializeField] private float interpolationTime;
    [SerializeField] private GameObject screen;

    [SerializeField] private Image image;

    private void Update()
    {
        Flash();
    }

    public IEnumerator Flash()
    {
        float t = 0;
        while (true)
        {
            yield return null;
            image.color = Color.Lerp(new Color(0f, 0f, 0f, 0f), new Color(0f, 0f ,0f, 255f), t / interpolationTime);
            t += Time.deltaTime;

            if (t > interpolationTime)
            {
                break;
            }

        }

    }

}
