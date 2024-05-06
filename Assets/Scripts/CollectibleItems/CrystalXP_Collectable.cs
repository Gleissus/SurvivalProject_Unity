using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalXP_Collectable : MonoBehaviour
{
    [SerializeField] private int valueXP = 10;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player")) 
        {
            SoundPlayer.GetInstance().PlayCollectedItemAudio();
            PlayerSkills.GetInstance().IncreaseXP(valueXP);
            gameObject.SetActive(false);
        }
    }

}
