using UnityEngine;
using TMPro;

public class InteractionHint : MonoBehaviour
{
    private IInteractable currentInteractable;
    private Transform mainCamera;
    public TextMeshProUGUI NormalInteractionText; //set in prefab inspector
    public TextMeshProUGUI SpecialInteractionText; //set in prefab inspector

    private void Awake()
    {
        mainCamera = Camera.main.transform;
        GameEventSystem.ShowInteractionHintEvent += Show;
        GameEventSystem.RefreshInteractionHintEvent += Refresh;
        GameEventSystem.HideInteractionHintEvent += Hide;
        GameEventSystem.BeginLongInteractionEvent += Hide;
        GameEventSystem.EndLongInteractionEvent += Show;
        gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        GameEventSystem.ShowInteractionHintEvent -= Show;
        GameEventSystem.RefreshInteractionHintEvent -= Refresh;
        GameEventSystem.HideInteractionHintEvent -= Hide;
        GameEventSystem.BeginLongInteractionEvent -= Hide;
        GameEventSystem.EndLongInteractionEvent -= Show;
    }

    private void Update()
    {
        //orienta continuamente l'oggetto verso la telecamera quando è attivo
        transform.forward = mainCamera.transform.forward;
    }

    /// <summary>
    /// Show AND Refresh the interaction hint with the interaction texts provided by the interactable.
    /// </summary>
    /// <param name="interactable"></param>
    private void Show(IInteractable interactable)
    {
        if (interactable.IsInteractable) //se l'interactable è interagibile
        {
            gameObject.SetActive(true); //attiva l'intero oggetto
            currentInteractable = interactable;
            Refresh(interactable); //refresha i testi di interazione
        }
    }

    /// <summary>
    /// <para>Only refresh the interaction hint with the interaction texts provided by the interactable.</para>
    /// <para>Beware, the refresh is done only if the given interactable is the same you are near to.</para>
    /// </summary>
    /// <param name="interactable"></param>
    private void Refresh(IInteractable interactable)
    {
        //il refresh può essere chiamato anche da interagibili lontani se un altro player ci ha interagito.
        //se il mio interactable attuale non è lo stesso che sta chiamando il refresh, non refresharlo!
        if (interactable == currentInteractable)
        {
            //i due testi sono messi dentro un vertical layout group quindi disattivandoli/attivandoli, si riadattano automaticamente!
            NormalInteractionText.text = interactable.NormalInteractionHintText; //prendi il testo normale
            if (NormalInteractionText.text != "") //se esiste (quindi c'è un'azione normale possibile)
                NormalInteractionText.gameObject.SetActive(true); //attiva l'oggetto testo
            else
                NormalInteractionText.gameObject.SetActive(false); //altrimenti disattivalo

            SpecialInteractionText.text = interactable.SpecialInteractionHintText; //prendi il testo speciale
            if (SpecialInteractionText.text != "") //se esiste (quindi c'è un'azione speciale possibile)
                SpecialInteractionText.gameObject.SetActive(true); //attiva l'oggetto del testo
            else
                SpecialInteractionText.gameObject.SetActive(false); //altrimenti disattivalo
        }

    }

    /// <summary>
    /// Clean and Hide the interaction hint.
    /// </summary>
    private void Hide()
    {
        NormalInteractionText.text = ""; //pulisci il testo normale
        SpecialInteractionText.text = ""; //pulisci il testo speciale
        gameObject.SetActive(false); //disattiva l'intero oggetto
        currentInteractable = null; //tolgo la reference al currentInteractable
    }
}
