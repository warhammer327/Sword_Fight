using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealtPlayerOne : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator anim;
    int maxHealth = 100;
    public int curHealth;
    [SerializeField]
    GameObject playerTwoWinningScreen;
    void Start()
    {
       curHealth = maxHealth; 
    }

    // Update is called once per frame
    public void TakeDamage(int damage)
    {
        if(curHealth<=0)
        {
            Debug.Log("Player One Died");
            anim.SetTrigger("Death");
            this.enabled = false;
            playerTwoWinningScreen.SetActive(true);
        }
        else
        {
            curHealth -=damage;
            Debug.Log("Player One Hit");
            anim.SetTrigger("Hurt");
        }
    }
}
