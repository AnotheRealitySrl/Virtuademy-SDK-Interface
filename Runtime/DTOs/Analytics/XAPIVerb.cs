using System;
using UnityEngine;

namespace Virtuademy.SDK.ApiData
{
    [Serializable]
    [Newtonsoft.Json.JsonObject(Newtonsoft.Json.MemberSerialization.Fields)]
    public class XAPIVerb
    {
        [SerializeField] private string id;
        [SerializeField] private string label;
    }
}
