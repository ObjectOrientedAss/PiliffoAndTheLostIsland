using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingStep
{
    public BuildingStepRequirements[] Requirements;

    public BuildingStep(BuildingStepSO stepSO)
    {
        Requirements = new BuildingStepRequirements[stepSO.Requirements.Length];
        for (int i = 0; i < Requirements.Length; i++)
        {
            Requirements[i] = new BuildingStepRequirements();
            Requirements[i].GivenQuantity = stepSO.Requirements[i].GivenQuantity;
            Requirements[i].ItemType = stepSO.Requirements[i].ItemType;
            Requirements[i].Quantity = stepSO.Requirements[i].Quantity;
        }
    }
}
