using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterStats))]
public class Combat : MonoBehaviour
{
    public float attackSpeed = 0.1f;
    private float attackCooldown = 0f;
    public float attackDelay = 1f;
    public event System.Action OnAttack;
    CharacterStats mStats;
    private void Start()
    {
        mStats = GetComponent<CharacterStats>();
    }
    private void Update()
    {
        attackCooldown -= Time.deltaTime;
    }
    public void Attack(CharacterStats tstats)
    {
        if (attackCooldown <= 0f)
        {
            StartCoroutine(AnimDelay(tstats, attackDelay));
            OnAttack?.Invoke();
            attackCooldown = 1f / attackSpeed;
        }
    }
    IEnumerator AnimDelay(CharacterStats stats , float delay)
    {
        yield return new WaitForSeconds(delay);
        stats.Damage(mStats.damage.GetValue());

    }
}
