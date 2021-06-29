using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IKController : MonoBehaviour
{
    public Transform Head;
    public Transform Left;
    public Transform Right;

    public Transform Target;

    public bool isIkActive;
    public bool isGroup;

    public Animator _anim;
    // Start is called before the first frame update
    void Start()
    {
        _anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // добавить, что это работает при приближении к персонажу 
    void OnAnimatorIK(int layerIndex)
    {
        if(!_anim)
        {
            return;
        }

        if (isIkActive) {
            
            if (!Head)
            {
                return;
            }

            _anim.SetLookAtWeight(1);
            _anim.SetLookAtPosition(Target.position);
            Head.LookAt(Target);

            if (!Left) { return; }
            _anim.SetIKPositionWeight(AvatarIKGoal.RightHand, 1);
            _anim.SetIKPosition(AvatarIKGoal.RightHand, Right.position);


            _anim.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1);
            _anim.SetIKPosition(AvatarIKGoal.LeftHand, Left.position);


        }
        if(isGroup)
        {
            Left.SetParent(Head);
            Right.SetParent(Head);
        }
        
    }
}
