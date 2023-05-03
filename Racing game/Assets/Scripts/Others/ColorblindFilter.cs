using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorblindFilter : MonoBehaviour
{
    public Button toggleButton; // Button to toggle the filter
    public Image filterImage; // Image to apply the filter to
    public Color[] colorblindColors; // Colors to use for the filter (e.g. colorblind-friendly palette)

    private bool isFilterOn = false; // Whether the filter is currently active

    private void Start()
    {
        toggleButton.onClick.AddListener(ToggleFilter);
    }

    private void ToggleFilter()
    {
        isFilterOn = !isFilterOn;

        if (isFilterOn)
        {
            filterImage.material = new Material(Shader.Find("UI/ColorblindFilter"));
            filterImage.material.SetInt("_IsFilterOn", 1);
            filterImage.material.SetInt("_ColorblindType", 0);
            filterImage.material.SetInt("_NumColors", colorblindColors.Length);
            filterImage.material.SetColorArray("_Colors", colorblindColors);
        }
        else
        {
            filterImage.material = null;
        }
    }
}
