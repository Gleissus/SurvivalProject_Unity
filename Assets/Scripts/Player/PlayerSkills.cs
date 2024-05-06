using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class PlayerSkills : MonoBehaviour
{
    private static PlayerSkills instance;

    [Header("LevelUP variables")]
    [SerializeField] private int currentXP;
    [SerializeField] private int currentLevel;
    [SerializeField] private int baseXPLevelUp = 50;
    [Header("Scyth variables")]
    [SerializeField] private AudioSource scythAudio;
    [SerializeField]private float scythIntervalAttack = 3;
    [SerializeField]private float scythAmountAttack = 3;
    
    public static PlayerSkills GetInstance() => instance;
    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        currentLevel = 0;
        currentXP = 0;

        InvokeRepeating("ScytheAttack", 2f, scythIntervalAttack);
    }

    public void IncreaseXP(int value)
    {
        currentXP += value;
        UIController.instance.PrintXPAmount(currentXP);

        CheckLevelUp();
    }

    private void CheckLevelUp()
    {
        int xpToLevelUp = baseXPLevelUp; 
        float xpIncreaseFactor = 1.1f; 

        while (currentXP >= xpToLevelUp)
        {
            currentXP -= xpToLevelUp; 
            currentLevel++;
            UIController.instance.PrintLevelAmount(currentLevel);

            //Scyth Attack Upgrade
            scythAmountAttack += (currentLevel % 5 == 0) ? 1 : 0;
            //Suriken Attack Upgrade
            if(currentLevel % 5 == 0)
            {
                SurikenWeapon.GetInstance().LevelUpdate();
            }

            xpToLevelUp = Mathf.RoundToInt(xpToLevelUp * xpIncreaseFactor); 
        }
        
    }

    private void ScytheAttack()
    {
        scythAudio.Play();

        for (int i = 0; i < scythAmountAttack; i++)
        {
            GameObject scythe = ObjectPool.GetInstance().GetPooledObject();
            scythe.transform.position = transform.position;
            scythe.SetActive(true);
        }

    }

    public int GetCurrentLevel()
    {        
        return currentLevel;
    }
}
