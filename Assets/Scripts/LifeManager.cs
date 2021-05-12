using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

enum Owner
{
    Player, Enemy
}
public class LifeManager : MonoBehaviour
{
    public int Life = 50;
    public Slider LifeBar;
    public GameObject ImageDie;

    float counter = 5;
    [SerializeField]
    Owner owner;

    [HideInInspector]
    public int AcctuallyLife;

    private void Start()
    {
        AcctuallyLife = Life;
        counter = 5;
        if (LifeBar != null)
        {
            LifeBar.maxValue = Life;
            LifeBar.value = Life;
        }
    }
    private void OnEnable()
    {
        AcctuallyLife = Life;
        if (LifeBar != null)
        {
            LifeBar.maxValue = Life;
            LifeBar.value = Life;
        }
    }

    public void AddDamage(int damage)
    {
        AcctuallyLife -= damage;
        if (LifeBar != null)
            LifeBar.value = AcctuallyLife;

        if (AcctuallyLife <= 0)
            OnDead();
    }

    void OnDead()
    {
        switch (owner)
        {
            case Owner.Player:
                ImageDie.SetActive(true);

               

                break;

            case Owner.Enemy:
                gameObject.SetActive(false);
                gameObject.GetComponent<EnemyBehaviour>().OnDeath();
                break;
        }
    }
}
