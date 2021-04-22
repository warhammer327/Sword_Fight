using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPlayerTwo : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator anim;
    [SerializeField]
    GameObject playerOneWinningScreen;
    int maxHealth = 100;
    public int curHealth;
    void Start()
    {
       curHealth = maxHealth; 
    }

    // Update is called once per frame
    public void TakeDamage(int damage)
    {
        if(curHealth<=0)
        {
            anim.SetTrigger("Death");
            Debug.Log("Player Two Died");
           // GetComponent<Collider2D>().enabled = false;
            this.enabled = false;
            playerOneWinningScreen.SetActive(true);
        }
        else
        {
            //yield return new WaitForSeconds(1);
            
            curHealth -=damage;
            Debug.Log("Player Two Hit");
            anim.SetTrigger("Hurt");
        }
    }

}
