using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RecipeSpecificsPanelBehaviour : MonoBehaviour
{
    public GameObject CraftButton;
    public GameObject CraftingRequirementItemPrefab;
    public Recipe SelectedRecipe;

    public void Refresh(Recipe recipe)
    {
        Clear();

        int possessedMaterialsCounter = 0;
        for (int i = 0; i < recipe.Requirements.Length; i++)
        {
            GameObject item = Instantiate(CraftingRequirementItemPrefab, transform);
            item.GetComponent<CraftingRequirementItemUI>().Name.text = recipe.Requirements[i].ItemType.ToString();
            ItemSlot slot = Inventory.FindSlot(recipe.Requirements[i].ItemType.ToString());

            if (slot != null)
            {
                item.GetComponent<CraftingRequirementItemUI>().Quantity.text = slot.Quantity.ToString() + " / " + recipe.Requirements[i].NeededQuantity.ToString();
                if (slot.Quantity >= recipe.Requirements[i].NeededQuantity)
                {
                    possessedMaterialsCounter++;
                }
            }
            else
                item.GetComponent<CraftingRequirementItemUI>().Quantity.text = "0 / " + recipe.Requirements[i].NeededQuantity.ToString();
        }

        SelectedRecipe = recipe;
        if (possessedMaterialsCounter == SelectedRecipe.Requirements.Length)
            CraftButton.SetActive(true);
        else
            CraftButton.SetActive(false);
    }

    public void Clear()
    {
        for (int i = transform.childCount - 1; i >= 0; i--)
        {
            Destroy(transform.GetChild(i).gameObject);
        }
        SelectedRecipe = null;
    }
    public void CraftButtonClick()
    {
        for (int i = 0; i < SelectedRecipe.Requirements.Length; i++)
        {
            GameEventSystem.CraftItem(SelectedRecipe.Requirements[i].ItemType.ToString(), SelectedRecipe.Requirements[i].NeededQuantity);
        }
        Refresh(SelectedRecipe);

        if (SelectedRecipe.RecipeName == "Hat")
        {
            HatManager.Instance.AddHat();
            return;
        }

        GameObject go = Instantiate(SelectedRecipe.Prefab);
        Pickable pickable = go.GetComponent<Pickable>();
        pickable.CreateItem();
        pickable.Item.Quantity = SelectedRecipe.OutputQuantity;

        

        GameEventSystem.AddInventoryItem(pickable, SelectedRecipe.OutputQuantity);
    }
    private void hatCrafting()
    {
        for (int i = 0; i < SelectedRecipe.Requirements.Length; i++)
        {
            GameEventSystem.CraftItem(SelectedRecipe.Requirements[i].ItemType.ToString(), SelectedRecipe.Requirements[i].NeededQuantity);
        }
        HatManager.Instance.AddHat();
    }

}
