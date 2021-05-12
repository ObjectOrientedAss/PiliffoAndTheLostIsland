using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Crafting Recipes/New Crafting Recipe")]
public class RecipeSO : ScriptableObject
{
    public GameObject Prefab;
    public string RecipeName;
    public int OutputQuantity;
    public bool Acquired; //<- can the player craft this?

    public CraftingRequirements[] Requirements;
}
