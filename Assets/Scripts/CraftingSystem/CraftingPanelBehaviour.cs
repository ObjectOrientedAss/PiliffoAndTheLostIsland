using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingPanelBehaviour : MonoBehaviour
{
    public Recipe[] AllRecipes;
    public GameObject RecipeItemPrefab;
    public Transform RecipesParent;
    public RecipeSpecificsPanelBehaviour SpecificsPanelBehaviour;

    private void Awake()
    {
        gameObject.SetActive(false);
        GameEventSystem.LoadAllRecipesEvent += LoadAllRecipes;
    }

    private void OnDestroy()
    {
        GameEventSystem.LoadAllRecipesEvent -= LoadAllRecipes;
    }

    private void OnEnable()
    {
        //build recipes items
        for (int i = 0; i < AllRecipes.Length; i++)
        {
            RecipesParent.GetChild(i).gameObject.SetActive(AllRecipes[i].Acquired);
        }

        SpecificsPanelBehaviour.CraftButton.SetActive(false);
    }

    private void OnDisable()
    {
        //destroy all requirements panel childs
        SpecificsPanelBehaviour.Clear();
    }

    private void LoadAllRecipes(ref Recipe[] recipes)
    {
        AllRecipes = recipes;

        for (int i = 0; i < recipes.Length; i++)
        {
            GameObject item = Instantiate(RecipeItemPrefab, RecipesParent);
            RecipeUI script = item.GetComponent<RecipeUI>();
            script.Recipe = recipes[i];
            script.RecipeName.text = recipes[i].RecipeName;
            script.OutputQuantity.text = recipes[i].OutputQuantity.ToString();
            script.SpecificsBehaviour = SpecificsPanelBehaviour;
        }
    }

    public void CloseButtonClick()
    {
        //interrupt crafting interaction
        GameEventSystem.ToggleCraftingUI(false);
    }
}