using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using FunkySheep.Network;
using FunkySheep.Variables;

[RequireComponent(typeof(UIDocument))]
public class Nickname : MonoBehaviour
{
    public StringVariable nickname;
    public Service service;
    public void set()
    {
        GetComponent<UIDocument>().rootVisualElement.Q<TextField>("nickname").value = nickname.Value;
        GetComponent<UIDocument>().rootVisualElement.Q<TextField>("nickname").RegisterCallback<KeyUpEvent>(this.send);
    }

    public void send(KeyUpEvent evt) {
        nickname.Value = GetComponent<UIDocument>().rootVisualElement.Q<TextField>("nickname").value;
        service.PatchRecords(User.Instance._id.Value);
    }
}
