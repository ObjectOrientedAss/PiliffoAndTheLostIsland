using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickable : MonoBehaviour, IInteractable
{
    //IInteractable-----
    public bool IsInteractable { get; set; }
    public InteractableType InteractableType { get { return InteractableType.Pickable; } }
    public string NormalInteractionHintText { get { return "Pick Up \n" + Item.Quantity + "  " + Item.Name; } }
    public string SpecialInteractionHintText { get { return ""; } }

    public AnimationType NormalInteractionAnimation { get { return AnimationType.None; } }
    public AnimationType SpecialInteractionAnimation { get { return AnimationType.None; } }

    //IInteractable-----

    public Item_SO ItemSO;
    public Item Item;

    [HideInInspector]
    public ItemSpawner Spawner;





    private void OnEnable()
    {
        IsInteractable = true;
        
    }

    private void OnDisable()
    {
        IsInteractable = false;
    }

    public void CreateItem()
    {
        Item = new Item(ItemSO);
    }

    public void ObjectPicked()
    {
        if (Spawner != null)
            Spawner.CanSpawn = true;
    }

    //IInteractable-----
    public void StartNormalInteraction()
    {
  
        
        GameEventSystem.AddInventoryItem(this, Item.Quantity);
        //GameEventSystem.DestroyInteractable(this);
        //Destroy(gameObject); //<- se usiamo il pooling agire qui al posto di Destroy!
    }

    public Vector3 GetPosition()
    {
        return transform.position;
    }

    public void CompleteNormalInteraction()
    {
        //required empty stub
    }

    public void StartSpecialInteraction()
    {
        //required empty stub
    }

    public void CompleteSpecialInteraction()
    {
        //required empty stub
    }

    public void InterruptInteraction()
    {
        //required empty stub
    }
    //IInteractable-----
}
