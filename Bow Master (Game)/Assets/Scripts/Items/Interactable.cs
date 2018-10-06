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
            
            //if item enum is Heal and player is less than max health
            if (itemEffect.Equals("Heal") && playerHealth.currentHealth < playerHealth.startingHealth) {
                playerHealth.currentHealth += itemStrength; //heal player
                gameManager.RemoveCurrency(itemCost); //remove currency
                Destroy(gameObject); //destroy object
            }

            if (itemEffect.Equals("Range")) { //if item enum is Range
                PlayerShooting.range += itemStrength; //increase player range
                gameManager.RemoveCurrency(itemCost); //remove currency
                Destroy(gameObject); //destroy object
            }

            if (itemEffect.Equals("Damage")) { //if enum is Damage
                PlayerShooting.damage += itemStrength; //increase player damage
                gameManager.RemoveCurrency(itemCost); //remove currency
                Destroy(gameObject); //destroy object
            }
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
