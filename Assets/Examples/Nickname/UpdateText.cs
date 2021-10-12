using UnityEngine;
using UnityEngine.UIElements;
using FunkySheep.Network;
using FunkySheep.Variables;

[RequireComponent(typeof(UIDocument))]
public class UpdateText : MonoBehaviour
{
  public StringVariable text;
  public Service service;
  private TextField _textField;

  public void Awake() {
    this._textField = GetComponent<UIDocument>().rootVisualElement.Q<TextField>("input-nickname");
    this._textField.RegisterCallback<KeyUpEvent>(this.SendText);
  }

  public void SetText() {
    this._textField.value = this.text.Value;
  }

  public void SendText(KeyUpEvent evt) {
    this.text.Value = this._textField.value;
    service.PatchRecords(User.Instance._id.Value);
  }
}
