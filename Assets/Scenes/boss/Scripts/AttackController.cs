using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttackController : MonoBehaviour
{
    //public Transform _teleportCollider;
    public Transform player;
   // public Slider healtbar;
    static Animator _anim;

    //private Animations anim;
    // Start is called before the first frame update
    void Start()
    {
        _anim = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
        //if (healtbar.value <= 0) return;
        if (Vector3.Distance(player.position, this.transform.position) < 15f)
        {
            if (Vector3.Distance(player.position, this.transform.position) < 10f)
            {
                Vector3 direction = player.position - this.transform.position;
                direction.y = 0;

                this.transform.rotation = Quaternion.Slerp(this.transform.rotation,
                    Quaternion.LookRotation(direction), 0.08f);
                _anim.SetBool("walk", false);
                _anim.SetBool("Idle", false);
                _anim.SetBool("attack3", false);
                
                Debug.Log("IDK");
                if (direction.magnitude > 1f )
                {
                    _anim.SetBool("attack3", false);
                    _anim.SetBool("Idle", false);
                    _anim.SetBool("run", true);
                    this.transform.Translate(0, 0, 0.05f);
                    
                    
                    Debug.Log("run");

                }
               
                if ( direction.magnitude < 1f)
                {
                    
                    _anim.SetBool("run", false);
                    _anim.SetBool("Idle", false);
                    _anim.SetBool("attack3", true);
                    Debug.Log("attack");
                    
                }
               
            }
            else
            {
                Vector3 endpoint = player.position;// _teleportCollider.position;
                endpoint.y = 0;
                TeleportBehind(endpoint);
            }
        }
        else
        {
            _anim.SetBool("attack3", false);
            _anim.SetBool("Idle", true);
            Debug.Log("Idle");
        }
        
      

    }
    void TeleportBehind(Vector3 point)
    {
        Debug.Log("teleportin");
        this.transform.position = point+ point.normalized;
    }
    class Animations
    {
        public Animator _animator;
        public void startIdle()
        {
            _animator.SetBool("Idle", true);
        }
        public void stopIdle()
        {
            _animator.SetBool("Idle", false);
        }
        public void startWalk()
        {
            _animator.SetBool("walk", true);
        }
        public void stopWalk()
        {
            _animator.SetBool("walk", false);
        }
        public void startRun()
        {
            _animator.SetBool("run", true);
        }
        public void stopRun()
        {
            _animator.SetBool("run", false);
        }
        public void startAttack()
        {
            _animator.SetBool("attack3", true);
        }
        public void stopAttack()
        {
            _animator.SetBool("attack3", false);
        }
        public void startDeath()
        {
            _animator.SetBool("death", true);
        }

    }
}
