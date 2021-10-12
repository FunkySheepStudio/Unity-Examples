using UnityEngine;
using FunkySheep.Variables;
using FunkySheep.Network;

public class UpdatePosition : MonoBehaviour
{    
  public Service service;
  public FloatVariable xposition;
  public FloatVariable yposition;
  public FloatVariable zposition;

  [SerializeField]
  private bool _moving = false;

  private float _lastXposition;
  private float _lastYposition;
  private float _lastZposition;

  public int frequency = 1000;
  private float _lastSentDelta = 0;

  void Update() {
    bool send = false;
    _lastSentDelta += UnityEngine.Time.deltaTime;

    //  If position changed
    if (transform.position.x != _lastXposition || transform.position.y != _lastYposition || transform.position.z != _lastZposition)
    {
      xposition.Value = _lastXposition = transform.position.x;
      yposition.Value = _lastYposition = transform.position.y;
      zposition.Value = _lastZposition = transform.position.z;
      send = true;
    }

    if (_lastSentDelta * 1000 > frequency && send && _moving) {
      service.PatchRecords();
      _lastSentDelta = 0;
    }
  }

  public void onNetworkUpdate() {
    transform.localPosition = new Vector3(xposition.Value, yposition.Value, zposition.Value);
    _lastXposition = transform.position.x;
    _lastYposition = transform.position.y;
    _lastZposition = transform.position.z;
  }

  public void startMoving() {
    _moving = true;
  }
  public void stopMoving() {
    _moving = false;
  }
}
