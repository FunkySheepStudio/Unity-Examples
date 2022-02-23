using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Receiver : MonoBehaviour
{
    public void OnGameEventReceived()
    {
        Debug.Log("Game Event Received");
    }

    public void OnGameEventGOReceived(GameObject GO)
    {
        Debug.Log("Game Event GO Received " + GO.name);
    }

    public void OnGameEventVector3Received(Vector3 vector3)
    {
        Debug.Log("Game Event Vector3 Received" + vector3);
    }

    public void OnGameEventVariableReceived(FunkySheep.Types.GenericType funkySheepVariable)
    {
        Debug.Log("Game Event Variable Received: " + funkySheepVariable.ToString());
    }
}
