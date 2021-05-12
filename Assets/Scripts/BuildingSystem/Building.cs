using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Building : MonoBehaviour, IInteractable
{
    public string NormalInteractionHintText { get { return "Build"; } }
    public string SpecialInteractionHintText { get { return ""; } }

    public bool IsInteractable { get; set; }

    public InteractableType InteractableType { get { return InteractableType.Building; } }
    public AnimationType NormalInteractionAnimation { get { return AnimationType.None; } }
    public AnimationType SpecialInteractionAnimation { get { return AnimationType.None; } }

    public int CurrentBuildingStep;
    public BuildingSO BuildingSO;
    public BuildingStep BuildingStep;
    public BuildingSpotHint BuildingSpotHint;

    private void Awake()
    {
        IsInteractable = false;
        CurrentBuildingStep = -1;
        GameEventSystem.ActivateBuildingSpotEvent += ActivateBuildingSpot;
    }

    private void OnDestroy()
    {
        GameEventSystem.ActivateBuildingSpotEvent -= ActivateBuildingSpot;
    }

    private void Start()
    {
        GameEventSystem.ActivateBuildingSpot(this); //test only
    }

    public void RefreshStep(int requirementIndex, int quantity)
    {
        BuildingStep.Requirements[requirementIndex].GivenQuantity = quantity;

        for (int i = 0; i < BuildingStep.Requirements.Length; i++)
        {
            if (BuildingStep.Requirements[i].GivenQuantity < BuildingStep.Requirements[i].Quantity)
                return;
        }
        Build(); //next step! if there is one at least...
    }

    private void ActivateBuildingSpot(Building building)
    {
        if(building == this)
        {
            BuildingSpotHint.gameObject.SetActive(true);
            IsInteractable = true;
            BuildingStep = new BuildingStep(BuildingSO.BuildingSteps[CurrentBuildingStep + 1]);
        }
    }

    private void Build()
    {
        //if (CurrentBuildingStep >= 0)
        //    transform.GetChild(CurrentBuildingStep).gameObject.SetActive(false);
        GameEventSystem.ProgressGame();

        CurrentBuildingStep++;
        transform.GetChild(CurrentBuildingStep).gameObject.SetActive(true);
        GameEventSystem.ToggleBuildingUI(false, null);

        if (CurrentBuildingStep == BuildingSO.BuildingSteps.Length - 1)
        {
            IsInteractable = false;
            Destroy(BuildingSpotHint.gameObject); //ebbasta co ste costruzioni cribbio!
            GameEventSystem.EndLongInteraction(this);
            return;
        }

        BuildingStep = new BuildingStep(BuildingSO.BuildingSteps[CurrentBuildingStep + 1]);
        GameEventSystem.ToggleBuildingUI(true, this);
    }

    public void CompleteNormalInteraction()
    {
        //Chiudere UI di building
    }

    public void CompleteSpecialInteraction()
    {
        
    }

    public Vector3 GetPosition()
    {
        return transform.position;
    }

    public void InterruptInteraction()
    {
        //Chiudere UI di building
        GameEventSystem.ToggleBuildingUI(false, null);
        GameEventSystem.EndLongInteraction(this);
    }

    public void StartNormalInteraction()
    {
        //1: Avvia LongInteraction, Apri UI di building e comunicagli che deve riguardare questo building.
        GameEventSystem.ToggleBuildingUI(true, this);
        GameEventSystem.BeginLongInteraction();
    }

    public void StartSpecialInteraction()
    {
        //required empty stub
    }
}
