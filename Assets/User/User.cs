using System;
using UnityEngine;
using FunkySheep.Network;

using FunkySheep.Events;


public class User : FunkySheep.Types.SingletonClass<User>
{
    public FunkySheep.Types.String _id;
    public FunkySheep.Types.String login;
    public FunkySheep.Types.String password;
    public FunkySheep.Types.String accessToken;
    public Service service;
    public Service authService;

    void Start() {
      if (Application.platform != RuntimePlatform.WebGLPlayer)
        //  setUserId(_id.Value);
        Auth();
    }

    void Auth() {
      authService.fields.Clear();
      FunkySheep.Types.String strategy = ScriptableObject.CreateInstance<FunkySheep.Types.String>();
      strategy.name = "strategy";
      if (accessToken.Value == null || accessToken.Value == "") {
        strategy.Value = "local";
        authService.fields.Add(new ServiceField("login", login));
        authService.fields.Add(new ServiceField("password", password));
        authService.fields.Add(new ServiceField("strategy", strategy));
      } else {
        strategy.Value = "jwt";
        authService.fields.Add(new ServiceField("accessToken", accessToken));
        authService.fields.Add(new ServiceField("strategy", strategy));
      }
      authService.CreateRecords();

      authService.fields.Clear();
    }

    // Get the message back from the server ans manually populates sub objects fields.    
    public void AuthResult() {
      _id.fromJSONNode(authService.lastRawMsg["data"]["user"]["_id"]);
      login.fromJSONNode(authService.lastRawMsg["data"]["user"]["login"]);
      accessToken.fromJSONNode(authService.lastRawMsg["data"]["accessToken"]);
      service.GetRecord();
    }

    /*  public void setUserId(string Id) {
      if (Application.platform == RuntimePlatform.WebGLPlayer) {
        _id.Value = Id;
      }
      
      service.GetRecord();
    } */

    public void setUserToken(string Token) {
      if (Application.platform == RuntimePlatform.WebGLPlayer) {
        accessToken.Value = Token;
      }

      Auth();
      
      //  service.GetRecord();
    }
}
