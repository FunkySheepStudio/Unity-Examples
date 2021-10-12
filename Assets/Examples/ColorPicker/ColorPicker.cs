using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FunkySheep.Variables;
using FunkySheep.Network;

public class ColorPicker : MonoBehaviour
{
    public StringVariable color;
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
