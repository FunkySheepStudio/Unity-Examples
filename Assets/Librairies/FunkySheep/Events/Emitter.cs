using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FunkySheep.Examples
{
    public class Emitter : MonoBehaviour
    {
        public FunkySheep.Events.GameEvent gameEvent;
        public FunkySheep.Events.GameEventGO gameEventGO;
        public FunkySheep.Events.GameEventVector3 gameEventVector3;
        public FunkySheep.Events.GameEventVariable gameEventVariable;
        public FunkySheep.Types.String eventString;
        // Start is called before the first frame update
        void Start()
        {
            RaiseEvents();
        }

        public void RaiseEvents()
        {
            gameEvent.Raise();
            gameEventGO.Raise(this.gameObject);
            gameEventVector3.Raise(this.transform.position);
            gameEventVariable.Raise(eventString);
        }
    }    
}
