using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FunkySheep.Network;

public class ColorPicker : MonoBehaviour
{
    public FunkySheep.Types.String color;
    public Service service;

    private void Start() {
        if (service) {
            service.GetRecord();
        }
    }

    public void setColor()
    {
        Color color = new Color();
        ColorUtility.TryParseHtmlString((string)this.color.Value, out color);
        this.GetComponent<MeshRenderer>().sharedMaterial.color = color;
    }
}
