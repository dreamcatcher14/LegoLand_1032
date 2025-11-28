using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossIntroState : IBossState
{
    private readonly BossController _boss;
    private bool _reachPoint;
    private float _waitTime;
    public BossIntroState (BossController boss){_boss = boss;}
    public void Enter()
    {
        if(_boss.animator){_boss.animator.SetBool("Move",true);}
        if(_boss.introTargetPoint != null)
        {
            _boss.nav.isStopped = false;
            _boss.nav.speed = _boss.normalSpeed;
            _boss.nav.SetDestination(_boss.player.position);
            _reachPoint = false;
        }
        else
        {
            _reachPoint = true; _waitTime = _boss.introEndDelay; _boss.animator.SetBool("Move",false);
        }
    }
    public void Tick()
    {
        if(!_reachPoint && _boss.introTargetPoint != null)
        {
            float dist = Vector3.Distance(_boss.transform.position, _boss.introTargetPoint.position);
            if(dist <= _boss.nav.stoppingDistance + 1.1f)
            {
                _reachPoint = true ; _waitTime = _boss.introEndDelay;
                _boss.animator.SetBool("Move",false); _boss.nav.isStopped = true;
            }
        }
        else
        {
            _waitTime -= Time.deltaTime;
            if (_waitTime <= 0)
            {
                Debug.Log("Boss intro finished");
                //_boss.stateMachine.ChangeState(new BossChaseState(_boss));
            }
        }
    }
    public void Exit()
    {
        
    }

}
