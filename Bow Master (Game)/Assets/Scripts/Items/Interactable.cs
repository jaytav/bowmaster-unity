using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interactable : MonoBehaviour {

    public enum Effect { Heal, Range, Damage } //what the item does
    public Effect selectedEffect;

    public int itemStrength; //strength of effect
    public int itemCost; //currency cost of item
    public string itemDesc; //item description

    public Text textPrice; //item price shown to player
    public Text textDesc; //item description shown to player
    public Canvas itemDescCanvas; //item canvas reference
    
    private string itemEffect; //what the item does in string
    
    private GameManager gameManager;
    private PlayerHealth playerHealth;

    void Start() {
        textDesc.text = itemDesc;

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
                PlayerShooting.range += itemStrength;
            }

            if (itemEffect.Equals("Damage")) { //if enum is Damage
                //increase player damage
                PlayerShooting.damage += itemStrength;
            }
            
            Destroy(gameObject); //destroy object
        }
        else print("not enough currency");
    }

    void OnTriggerEnter2D(Collider2D col) {
        if (col.tag == "Player") {
            itemDescCanvas.gameObject.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D col) {
        if (col.tag == "Player") {
            itemDescCanvas.gameObject.SetActive(false);
        }
    }
}
