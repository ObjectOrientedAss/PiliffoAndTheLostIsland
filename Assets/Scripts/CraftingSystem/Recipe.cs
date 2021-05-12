using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recipe
{
    public GameObject Prefab;
    public string RecipeName;
    public int OutputQuantity;
    public bool Acquired; //<- can the player craft this?

    public CraftingRequirements[] Requirements;

    public Recipe(RecipeSO so)
    {
        RecipeName = so.RecipeName;
        OutputQuantity = so.OutputQuantity;
        Acquired = so.Acquired;
        Prefab = so.Prefab;

        Requirements = new CraftingRequirements[so.Requirements.Length];

        for (int i = 0; i < Requirements.Length; i++)
        {
            Requirements[i] = new CraftingRequirements();
            Requirements[i].ItemType = so.Requirements[i].ItemType;
            Requirements[i].NeededQuantity = so.Requirements[i].NeededQuantity;
        }
    }
}
