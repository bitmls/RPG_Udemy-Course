using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHole_Skill : Skill
{
    [SerializeField] private GameObject blackHolePrefab;
    [SerializeField] private float maxSize;
    [SerializeField] private float growSpeed;
    [SerializeField] private float shrinkSpeed;
    [Space]
    [SerializeField] private int amountOfAttack;
    [SerializeField] private float cloneAttackCooldown;
    [SerializeField] private float blackHoleDuration;

    BlackHole_Skill_Controller currentBlackHoleScript;

    public override bool CanUseSkill()
    {
        return base.CanUseSkill();
    }

    public override void UseSkill()
    {
        base.UseSkill();

        GameObject newBlackHole = Instantiate(blackHolePrefab, player.transform.position, Quaternion.identity);

        currentBlackHoleScript = newBlackHole.GetComponent<BlackHole_Skill_Controller>();

        currentBlackHoleScript.SetupBlackHole(maxSize, growSpeed, shrinkSpeed, amountOfAttack, cloneAttackCooldown, blackHoleDuration);
    }

    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        base.Update();
    }

    public bool SkillCompleted()
    {
        if (!currentBlackHoleScript)
            return false;

        if (currentBlackHoleScript.playerCanExitState)
        {
            currentBlackHoleScript = null;
            return true;
        }

        return false;
    }
}
