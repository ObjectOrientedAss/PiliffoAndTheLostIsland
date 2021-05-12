using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//NOTE: only YOUR player prefab must have this gameobject with the relative components!
public class PlayerInteractionArea : MonoBehaviour
{
    public IInteractable NearestInteractable; //<- this is set when YOU enter/exit an IInteractable area.
    private Player player;

    private void Awake()
    {
        //if i am interacting, call stop interaction on that interactable. It will automatically trigger the right stop interaction event.
        player = GetComponentInParent<Player>();

        GameEventSystem.BeginLongInteractionEvent += BeginInteraction;
        GameEventSystem.EndLongInteractionEvent += EndInteraction;
        GameEventSystem.DestroyInteractableEvent += ClearInteractable;
    }

    private void BeginInteraction()
    {
        player.IsInteracting = true;
    }

    private void OnDestroy()
    {
        GameEventSystem.BeginLongInteractionEvent -= BeginInteraction;
        GameEventSystem.EndLongInteractionEvent -= EndInteraction;
        GameEventSystem.DestroyInteractableEvent -= ClearInteractable;
    }

    private void EndInteraction(IInteractable interactable)
    {
        player.IsInteracting = false;
    }

    private void Update()
    {
        if(NearestInteractable != null)
        {
            Vector3 d = NearestInteractable.GetPosition() - transform.parent.position;
            Debug.DrawLine(transform.parent.position, transform.parent.position + d, Color.red);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!player.IsInteracting)
        {
            if (other.gameObject.CompareTag("Interactable"))
            {
                IInteractable interactable = other.gameObject.GetComponent<IInteractable>();
                if (interactable.IsInteractable)
                {
                    NearestInteractable = interactable;
                    GameEventSystem.ShowInteractionHint(NearestInteractable);
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (!player.IsInteracting)
        {
            if (other.gameObject.CompareTag("Interactable"))
            {
                IInteractable interactable = other.gameObject.GetComponent<IInteractable>();
                if (NearestInteractable != null)
                {
                    if (NearestInteractable == interactable)
                    {
                        NearestInteractable = null;
                        GameEventSystem.HideInteractionHint();
                    }
                }
            }
        }
    }

    /// <summary>
    /// <para>This only works if the passed interactable is the same i am interacting with.</para>
    /// <para>Hide the interaction hint, remove the nearest interactable, stop interacting with it.</para>
    /// </summary>
    /// <param name="interactable"></param>
    private void ClearInteractable(IInteractable interactable)
    {
        if (NearestInteractable == interactable)
        {
            GameEventSystem.HideInteractionHint();
            NearestInteractable = null;
            player.IsInteracting = false;
        }
    }
}
