using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interactable : MonoBehaviour {

    public enum Effect { Heal, Range } //what the item does
    public Effect selectedEffect;

    public int itemStrength; //strength of effect
    public int itemCost; //currency cost of item

    public Text textPrice; //item price shown to player
    
    private string itemEffect; //what the item does in string
    private GameManager gameManager;
    private PlayerHealth playerHealth;

    void Start() {
         itemEffect = selectedEffect.ToString();
         gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
         playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();

         textPrice.text = itemCost.ToString();
    }

	public void DoEffect() {
        if (gameManager.currency >= itemCost) { //only do effect if player has enough currency
            
            gameManager.RemoveCurrency(itemCost); //remove currency
            
            if (itemEffect.Equals("Heal")) { //if item enum is Heal
                //heal player
                playerHealth.currentHealth += itemStrength;
            }

            if (itemEffect.Equals("Range")) { //if item enum is Range
                //increase player range
                Debug.Log("Range lol");
            }
            
            Destroy(gameObject); //destroy object
        }
        else print("not enough currency");
    }
}
