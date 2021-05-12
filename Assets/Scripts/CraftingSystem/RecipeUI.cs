using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class RecipeUI : MonoBehaviour, IPointerClickHandler
{
    public TextMeshProUGUI RecipeName;
    public TextMeshProUGUI OutputQuantity;
    [HideInInspector] public Recipe Recipe;
    [HideInInspector] public RecipeSpecificsPanelBehaviour SpecificsBehaviour;

    public void OnPointerClick(PointerEventData eventData)
    {
        SpecificsBehaviour.Refresh(Recipe);
    }
}
