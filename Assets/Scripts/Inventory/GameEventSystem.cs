using System.Collections.Generic;

public delegate void OnTogglePauseUI(bool show);
public delegate void OnTryInterruptPause();
public delegate void OnDestroyInteractable(IInteractable interactable);
public delegate void OnLongInteractionBegin();
public delegate void OnLongInteractionEnd(IInteractable interactable);
public delegate void OnShowInteractionHint(IInteractable interactable);
public delegate void OnRefreshInteractionHint(IInteractable interactable);
public delegate void OnHideInteractionHint();

public delegate void OnAddInventoryItem(Pickable pickable, int quantity);
public delegate void OnChangeInventoryMaxSlots(int slots);
public delegate void OnAddInventorySlot(Item item);
public delegate void OnRemoveInventorySlot(string itemName);
public delegate void OnChangeInventorySlotQuantity(string itemName, int quantity);
public delegate void OnDropInventoryItem(string itemName, int quantity);
public delegate void OnEquipItem(string itemName);
public delegate void OnUnequipItem();

public delegate void OnActivateBuildingSpot(Building building);
public delegate void OnToggleBuildingUI(bool activeStatus, Building building);
public delegate void OnTryGiveMaterialToBuild(string materialName, int quantity);
public delegate void OnGiveMaterial(int quantity);

public delegate void OnToggleCraftingUI(bool activeStatus);
public delegate void OnAcquireCraftingRecipe(string recipeName);
public delegate void OnLoadAllRecipes(ref Recipe[] recipes);
public delegate void OnCraftItem(string itemName, int quantity);

//progression
public delegate void OnProgressGame();
public delegate void OnWinGame();

public delegate void OnShowFastPopup(string message, float time);
public delegate void OnShowDialogPopup(List<string> messages, string buttonText);
public delegate void OnLoseGame();

public class GameEventSystem
{
    public static event OnTogglePauseUI TogglePauseUIEvent;
    public static event OnTryInterruptPause TryInterruptPauseEvent;

    public static event OnDestroyInteractable DestroyInteractableEvent;
    public static event OnLongInteractionBegin BeginLongInteractionEvent;
    public static event OnLongInteractionEnd EndLongInteractionEvent;
    public static event OnShowInteractionHint ShowInteractionHintEvent;
    public static event OnRefreshInteractionHint RefreshInteractionHintEvent;
    public static event OnHideInteractionHint HideInteractionHintEvent;

    //inventory
    public static event OnAddInventoryItem AddInventoryItemEvent;
    public static event OnChangeInventoryMaxSlots ChangeInventoryMaxSlotsEvent;
    public static event OnAddInventorySlot AddInventorySlotEvent;
    public static event OnRemoveInventorySlot RemoveInventorySlotEvent;
    public static event OnChangeInventorySlotQuantity ChangeInventorySlotQuantityEvent;
    public static event OnDropInventoryItem DropInventoryItemEvent;
    public static event OnEquipItem EquipItemEvent;
    public static event OnUnequipItem UnequipItemEvent;

    //building
    public static event OnActivateBuildingSpot ActivateBuildingSpotEvent;
    public static event OnToggleBuildingUI ToggleBuildingUIEvent;
    public static event OnTryGiveMaterialToBuild TryGiveMaterialToBuildEvent;
    public static event OnGiveMaterial GiveMaterialEvent;

    //crafting
    public static event OnToggleCraftingUI ToggleCraftingUIEvent;
    public static event OnAcquireCraftingRecipe AcquireCraftingRecipeEvent;
    public static event OnLoadAllRecipes LoadAllRecipesEvent;
    public static event OnCraftItem CraftItemEvent;
    public static event OnCraftItem CraftHatEvent;

    //progression
    public static event OnProgressGame ProgressGameEvent;
    public static event OnWinGame WinGameEvent;
    public static event OnLoseGame LoseGameEvent;

    public static event OnShowFastPopup ShowFastPopupEvent;
    public static event OnShowDialogPopup ShowDialogPopupEvent;

    public static void ShowFastPopup(string message, float time)
    {
        ShowFastPopupEvent.Invoke(message, time);
    }

    public static void ShowDialogPopup(List<string> messages, string buttonText)
    {
        ShowDialogPopupEvent.Invoke(messages, buttonText);
    }

    public static void EquipItem(string itemName)
    {
        EquipItemEvent.Invoke(itemName);
    }

    public static void UnequipItem()
    {
        UnequipItemEvent.Invoke();
    }

    public static void CraftItem(string itemName, int quantity)
    {
        CraftItemEvent.Invoke(itemName, quantity);
    }
    public static void CraftHat(string itemName, int quantity)
    {
        CraftHatEvent.Invoke(itemName, quantity);
    }

    public static void LoadAllRecipes(ref Recipe[] recipes)
    {
        LoadAllRecipesEvent.Invoke(ref recipes);
    }

    public static void ActivateBuildingSpot(Building building)
    {
        ActivateBuildingSpotEvent.Invoke(building);
    }

    public static void ToggleBuildingUI(bool activeStatus, Building building)
    {
        ToggleBuildingUIEvent.Invoke(activeStatus, building);
    }

    public static void TryGiveMaterialToBuild(string materialName, int quantity)
    {
        TryGiveMaterialToBuildEvent.Invoke(materialName, quantity);
    }

    public static void GiveMaterial(int quantity)
    {
        GiveMaterialEvent.Invoke(quantity);
    }

    public static void ToggleCraftingUI(bool activeStatus)
    {
        ToggleCraftingUIEvent.Invoke(activeStatus);
    }

    public static void AcquireCraftingRecipe(string recipeName)
    {
        AcquireCraftingRecipeEvent.Invoke(recipeName);
    }

    /// <summary>
    /// You should call this when you want the interaction hint to appear.
    /// </summary>
    /// <param name="interactable"></param>
    public static void ShowInteractionHint(IInteractable interactable)
    {
        ShowInteractionHintEvent.Invoke(interactable);
    }

    /// <summary>
    /// You should call this when for any reason, the interaction hint must be refreshed.
    /// </summary>
    /// <param name="interactable"></param>
    public static void RefreshInteractionHint(IInteractable interactable)
    {
        RefreshInteractionHintEvent.Invoke(interactable);
    }

    /// <summary>
    /// You should call this when you want the interaction hint to be hidden.
    /// </summary>
    public static void HideInteractionHint()
    {
        HideInteractionHintEvent.Invoke();
    }

    /// <summary>
    /// You should call this whenever an interaction which is not immediate begins.
    /// </summary>
    public static void BeginLongInteraction()
    {
        BeginLongInteractionEvent.Invoke();
    }

    /// <summary>
    /// You should call this whenever an interaction which is not immediate ends.
    /// </summary>
    /// <param name="interactable"></param>
    public static void EndLongInteraction(IInteractable interactable)
    {
        EndLongInteractionEvent.Invoke(interactable);
    }

    /// <summary>
    /// You should call this right before an interactable is removed from the scene and Destroy is called on it.
    /// </summary>
    /// <param name="interactable"></param>
    public static void DestroyInteractable(IInteractable interactable)
    {
        DestroyInteractableEvent.Invoke(interactable);
    }

    /// <summary>
    /// You should call this whenever the player enters or exits the Pause menu.
    /// </summary>
    /// <param name="show"></param>
    public static void TogglePauseUI(bool show)
    {
        TogglePauseUIEvent.Invoke(show);
    }

    /// <summary>
    /// You should call this whenever the player navigates back in the Pause menu.
    /// </summary>
    public static void TryInterruptPause()
    {
        TryInterruptPauseEvent.Invoke();
    }

    /// <summary>
    /// You should call this whenever the player picks an item.
    /// </summary>
    /// <param name="item"></param>
    public static void AddInventoryItem(Pickable pickable, int quantity)
    {
        AddInventoryItemEvent.Invoke(pickable, quantity);
    }

    public static void ChangeInventoryMaxSlots(int slots)
    {
        ChangeInventoryMaxSlotsEvent.Invoke(slots);
    }

    public static void AddInventorySlot(Item item)
    {
        AddInventorySlotEvent.Invoke(item);
    }

    public static void RemoveInventorySlot(string itemName)
    {
        RemoveInventorySlotEvent.Invoke(itemName);
    }

    public static void ChangeInventorySlotQuantity(string itemName, int quantity)
    {
        ChangeInventorySlotQuantityEvent.Invoke(itemName, quantity);
    }
    public static void DropInventoryItem(string itemName, int quantity)
    {
        DropInventoryItemEvent(itemName, quantity);
    }

    public static void ProgressGame()
    {
        ProgressGameEvent.Invoke();
    }

    public static void WinGame()
    {
        WinGameEvent.Invoke();
    }

    public static void LoseGame()
    {
        LoseGameEvent.Invoke();
    }
}