using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EquipTool : Equip
{
    public float attackRate;
    private bool attacking;
    public float attackDistance;

    public float useStamina;

    [Header("Resource Gathring")]
    public bool doesGatherResources;

    [Header("Combat")]
    public bool doesDealDamage;
    public int damage;

    private Animator animator;

    private Camera _camera;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        _camera = Camera.main;
    }

    public override void OnAttackInput()
    {
        if(!attacking)
        {
            if (CharacterManager.Instance.Player.condition.UseStamina(useStamina))
            {

                attacking = true;

                animator.SetTrigger("Attack");
                Invoke("OnCanAttack", attackRate);
            }
        }
    }

    void OnCanAttack()
    {
        attacking = false;
    }

    void OnHit()
    {
        Ray ray = _camera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        RaycastHit hit;

        if(Physics.Raycast(ray,out hit,attackDistance))
        {
            if(doesGatherResources && hit.collider.TryGetComponent(out Resource resource))
            {
                resource.Gather(hit.point, hit.normal);
            }
        }
    }

}
