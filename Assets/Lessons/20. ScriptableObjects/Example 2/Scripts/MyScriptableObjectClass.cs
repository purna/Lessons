using UnityEngine;
using System.Collections;
using System.Numerics;

[CreateAssetMenu(fileName = "Data", menuName = "Inventory/List", order = 1)]
public class MyScriptableObjectClass : ScriptableObject
{
    public string objectName = "New MyScriptableObject";
    public bool colorIsRandom = false;
    public Color thisColor = Color.white;
    public UnityEngine.Vector3[] spawnPoints;
}
