using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAnimationController : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    
    private readonly string _isBattle = "IsBattle";
    private readonly string _isVictory = "IsVictory";
    
    private readonly string _attackType = "AttackType";
    private readonly string _isAttack = "IsAttack";
    private readonly string _isDefense = "IsDefense";
    
    private readonly string _hit = "Hit";
    private readonly string _die = "Die";
    
    private int _attackTypeHash;
    private int _isAttackHash;
    private int _isBattleHash;
    private int _isVictoryHash;
    private int _isDefenseHash;
    private int _hitHash;
    private int _dieHash;
    
    private Dictionary<int, StateBehaviour> _stateBehaviours = new Dictionary<int, StateBehaviour>();
    
    public void InitOnCreate()
    {
        HashSetUp();
        _animator = GetComponentInChildren<Animator>();
    }

    public void Disable()
    {
        AnimEventReset();
    }

    private T GetAnimState<T>() where T : StateBehaviour
    {
        int hash = Animator.StringToHash(typeof(T).Name);
        T stateBehaviour;
        if(_stateBehaviours.ContainsKey(hash))
        {
            stateBehaviour = _stateBehaviours[hash] as T;
        }
        else
        {           
            stateBehaviour = _animator.GetBehaviour<T>();
            _stateBehaviours.Add(hash, stateBehaviour);    
        }

        return stateBehaviour;
    }
    
    public void AddAnimEnterEvent<T>(Action action) where T : StateBehaviour
    {
        T stateBehaviour = GetAnimState<T>();
        if(stateBehaviour) stateBehaviour.StateEnterEvent += action;
        
    }
    public void AddAnimEndEvent<T>(Action action) where T : StateBehaviour
    {
        T stateBehaviour = GetAnimState<T>();
        stateBehaviour.StateEndEvent += action;
    }
    public void RemoveAnimEnterEvent<T>(Action action) where T : StateBehaviour
    {
        T stateBehaviour = GetAnimState<T>();
        stateBehaviour.StateEnterEvent -= action;
    }
    public void RemoveAnimEndEvent<T>(Action action) where T : StateBehaviour
    {
        T stateBehaviour = GetAnimState<T>();
        stateBehaviour.StateEndEvent -= action;
    }

    public void AnimEventReset()
    {
        StateBehaviour[] stateBehaviours = _animator.GetBehaviours<StateBehaviour>();
        foreach (var stateBehaviour in stateBehaviours)
        {
            stateBehaviour.ResetEvent();
        }
    }
    
    
    private void HashSetUp()
    {
        _isAttackHash = Animator.StringToHash(_isAttack);
        _attackTypeHash = Animator.StringToHash(_attackType);
        _isBattleHash = Animator.StringToHash(_isBattle);
        _isVictoryHash = Animator.StringToHash(_isVictory);
        _isDefenseHash = Animator.StringToHash(_isDefense);
        _hitHash = Animator.StringToHash(_hit);
        _dieHash = Animator.StringToHash(_die);
    }

    public void Attack(int type)
    {
        _animator.SetInteger(_attackTypeHash, type);
        _animator.SetBool(_isAttackHash,true);
    }

    public void StopAttack()
    {
        _animator.SetBool(_isAttackHash,false);
    }
    
    public void Defense()
    {
        _animator.SetBool(_isDefenseHash,true);
    }
    public void StopDefense()
    {
        _animator.SetBool(_isDefenseHash,false);
    }
    
    public void Hit()
    {
        _animator.SetTrigger(_hitHash);
    }
    public void Die()
    {
        _animator.SetTrigger(_dieHash);
    }
    
    public void Battle()
    {
        _animator.SetBool(_isBattleHash,true);
    }
    public void StopBattle()
    {
        _animator.SetBool(_isBattleHash,false);
    }
    public void Victory()
    {
        _animator.SetBool(_isVictoryHash,true);
    }
    public void StopVictory()
    {
        _animator.SetBool(_isVictoryHash,false);
    }
}
