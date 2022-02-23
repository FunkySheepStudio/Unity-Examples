using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FunkySheep.SimpleJSON;

namespace FunkySheep.Examples.simpleJSON
{
    public class Reader : MonoBehaviour
    {
        [TextArea]
        public string jsonData = @"
        {
                ""name"": ""FunkySheep JSON test file"",
                ""version"": 0.1,
                ""container"":
                {
                    ""content"": ""content-data""
                },
                ""array"": [
                    ""Item1"",
                    ""Item2"",
                    ""Item3""
                ]
            }
        ";
        // Start is called before the first frame update
        void Start()
        {
            JSONNode node = JSONNode.Parse(jsonData);
            Debug.Log(node["name"]);
            Debug.Log(node["version"]);
            Debug.Log(node["container"]["content"]);

            for (int i = 0; i < node["array"].AsArray.Count; i++)
            {
                Debug.Log(node["array"][i]);
            }

        }
    }
}
