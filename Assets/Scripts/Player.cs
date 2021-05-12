using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Role { Villager, Courtesan, Guard, Villain, Last }
public enum FieldOfViewType { Circle, Cone }

public class Player : MonoBehaviour
{
    public DamageBehaviour Weapon;
    //This class should only contain the main player data, not behaviours!

    public bool IsPaused; //<- true if the player is in the pause menu
    public float MovementSpeed;
    public float RotationSpeed;
    public bool IsInteracting;
    public bool IsCrafting;
    public int StartingInventorySlots;
    [Header("Audio")]
    public List<AudioClip> attackClips;
    AudioSource src;

    private void Awake()
    {
        GameEventSystem.TogglePauseUIEvent += TogglePause;
        GameEventSystem.ToggleCraftingUIEvent += ToggleCraft;
        Inventory.MaxSlots = StartingInventorySlots;
        src = GetComponent<AudioSource>();
    }

    private void OnDestroy()
    {
        GameEventSystem.TogglePauseUIEvent -= TogglePause;
        GameEventSystem.ToggleCraftingUIEvent -= ToggleCraft;
    }

    private void TogglePause(bool status)
    {
        IsPaused = status;
    }

    private void ToggleCraft(bool status)
    {
        IsCrafting = status;
        if (!status)
            GetComponent<InputHandler>().GetPlayerControls().GamePlay.Movement.Enable();
        else
            GetComponent<InputHandler>().GetPlayerControls().GamePlay.Movement.Disable();
    }

    public void BeginSwing()
    {
        src.PlayOneShot(attackClips[Random.Range(0, attackClips.Count)], 0.5f);
        Weapon.CanDamage = true;
    }

    public void EndSwing()
    {
        Weapon.CanDamage = false;
    }
}