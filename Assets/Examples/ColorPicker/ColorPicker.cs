using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FunkySheep.Network;
using FunkySheep.Events;

public class ColorPicker : MonoBehaviour
{
    public FunkySheep.Types.String color;
    public Service service;

    public void setColor()
    {
        Color color = new Color();
        ColorUtility.TryParseHtmlString((string)this.color.Value, out color);
        this.GetComponent<MeshRenderer>().sharedMaterial.color = color;
    }
}
