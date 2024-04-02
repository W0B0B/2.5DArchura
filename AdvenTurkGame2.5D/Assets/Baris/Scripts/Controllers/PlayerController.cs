using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float MovingStep;
    [SerializeField] LayerMask triggerMask;
    [SerializeField] NavMeshAgent agent;
    [SerializeField] GameObject clickEffect;
    [SerializeField] Animator animator;
    Camera _mainCamera;
    
    Vector2 mousePosition;
    bool isclick;
    private void Awake() {
        _mainCamera=Camera.main;
    }
    
    private void Update() {
        OnClickInteract();
        OnClickMoving();    
    }
    public void OnClickInteract()
    {
        if (!Input.GetMouseButtonDown(0)) return;
        
        RaycastHit2D rayHit=Physics2D.Raycast(_mainCamera.ScreenToWorldPoint(Input.mousePosition),Vector3.forward,Mathf.Infinity,triggerMask);
        if(!rayHit.collider)
        { 
            return;
        } 
        
    }
    public void OnClickMoving()
    {
        if (!Input.GetMouseButtonDown(1)) return;
        RaycastHit hit;
        if (Input.GetMouseButtonDown(1))
        {
            if (Physics.Raycast(_mainCamera.ScreenPointToRay(Input.mousePosition),out hit,100,triggerMask))
            {
                
                agent.destination=new Vector3(hit.point.x,gameObject.transform.position.y,hit.point.z);    
                Instantiate(clickEffect,hit.point+new Vector3(0,0.1f,0),clickEffect.transform.rotation);
            }
            Vector3 dirToTarget=Vector3.Normalize(hit.point-transform.position);
            float dot=Vector3.Dot(transform.forward,dirToTarget);
            animator.SetFloat("x",dot);            
        }
            
        
    }

}
