using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Building/New Building")]
public class BuildingSO : ScriptableObject
{
    public string Name;
    public BuildingStepSO[] BuildingSteps;
}
