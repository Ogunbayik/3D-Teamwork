using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController 
{
    private Animator _animator;

    public AnimationController(Animator animator) => _animator = animator;
    public void PlayAnimation(int animationHash, float transitionTime)
    {
        if (_animator.GetCurrentAnimatorStateInfo(0).shortNameHash == animationHash)
            return;

        _animator.CrossFade(animationHash, transitionTime);
    }
    public bool IsAnimationFinish()
    {
        var currentAnimationIndex = 0;

        if (_animator.IsInTransition(currentAnimationIndex)) return false;

        AnimatorStateInfo stateInfo = _animator.GetCurrentAnimatorStateInfo(currentAnimationIndex);

        return !_animator.IsInTransition(0) && stateInfo.normalizedTime >= 1.0f;
    }
}
