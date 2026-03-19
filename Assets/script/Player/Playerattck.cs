using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playerattck : MonoBehaviour
{
    private Animator _animator;
    public int numOfClick = 0;
    float lastClickTime = 0f;
    float MaxComboDely = 0.9f;
    [SerializeField] private GameObject _weapon;
    // Start is called before the first frame update

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }
    void Start()
    {
        if( _weapon != null )
        {
            weapon weaponScript = _weapon.GetComponent<weapon>();
            if( weaponScript != null )
            {
                weaponScript.setAnimator(_animator);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (_animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.7f && _animator.GetCurrentAnimatorStateInfo(0).IsName("attack1"))
        {
            _animator.SetBool("attack1", false);
        }
        if (_animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.7f && _animator.GetCurrentAnimatorStateInfo(0).IsName("attack2"))
        {
            _animator.SetBool("attack2", false);
        }
        if (_animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.7f && _animator.GetCurrentAnimatorStateInfo(0).IsName("attack3"))
        {
            _animator.SetBool("attack3", false);
            numOfClick = 0;
        }
        if (_animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.7f && _animator.GetCurrentAnimatorStateInfo(0).IsName("Onhit"))
        {
            _animator.SetBool("Onhit", false);
            numOfClick = 0;
        }

        if (Time.time - lastClickTime > MaxComboDely)
        {
            numOfClick = 0;
            _animator.SetBool("attack1", false);
            _animator.SetBool("attack2", false);
            _animator.SetBool("attack3", false);
        }



        if (Input.GetMouseButtonDown(0))
        {
            lastClickTime = Time.time;
            numOfClick = Mathf.Clamp(numOfClick, 0, 3);
            numOfClick++;
            if (numOfClick == 1)
            {
                _animator.SetBool("attack1", true);
            }
            if (numOfClick >= 2 && _animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.7f && _animator.GetCurrentAnimatorStateInfo(0).IsName("attack1"))
            {
                _animator.SetBool("attack2", true);
                _animator.SetBool("attack1", false);
            }
            if (numOfClick >= 3 && _animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.7f && _animator.GetCurrentAnimatorStateInfo(0).IsName("attack2"))
            {
                _animator.SetBool("attack3", true);
                _animator.SetBool("attack2", false);
                _animator.SetBool("attack1", false);
            }

        }
    }
}
