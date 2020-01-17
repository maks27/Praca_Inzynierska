using UnityEngine;

public class Interactive : MonoBehaviour
{
    public float radius = 3f;
    public Transform Player;


    public virtual void Interact()
    {
       // Debug.Log("Press E to interact");
    }
    private void Update()
    {
    
        
            float distance = Vector3.Distance(Player.position, transform.position);
            if(distance <=radius)
            {
               Interact();
               
            }
        
    }
    
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

}
