using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    private Animator _animator;

    // STEP 1 -----------------------------------------------------------------
    // First, we are going to make our Pudu walk to where the player clicked
    //      by using its NavMeshAgent Component.
    // This feature will be done in Steps 1-3.
    //
    // Instead of making the NavMeshAgent a tunable variable in the Inspector,
    //      we're going to use GetComponent to find it.
    // Add a MEMBER VARIABLE here for the NavMeshAgent Component named _agent.
    // It does NOT need to be tunable in the Inspector.

    [SerializeField] private NavMeshAgent _agent;

    // STEP 1 -----------------------------------------------------------------


    // STEP 4 -----------------------------------------------------------------
    private Vector3 _lastKnownLocation;
    

    // STEP 4 -----------------------------------------------------------------

    private Camera _mainCamera;
    private RaycastHit _raycastHit;
    private bool _raycastSuccessful = false;
    private Ray _mouseRay;

    // STEP 2 -----------------------------------------------------------------
    // UNCOMMENT the below method and choose the right method name.
    // We're using this method to initialize a few of our member variables.
    // We only need it to run ONCE, when the game BEGINS.
    // What UNITY METHOD should we use for this?
    //
    // Once you've fixed the method signature, add a line INSIDE this method
    //      to use GetComponent to grab this GameObject's NavMeshAgent and store
    //      it in the _agent MEMBER VARIABLE.
    //
    private void Start()
    {
    
     _mainCamera = Camera.main;
     _animator = GetComponent<Animator>();
     _agent = GetComponent<NavMeshAgent>();
    }
    // STEP 2 -----------------------------------------------------------------

    // ------------------------------------------------------------------------
    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            _mouseRay = _mainCamera.ScreenPointToRay(Input.mousePosition);
            _raycastSuccessful = Physics.Raycast(_mouseRay, out _raycastHit);

            if (_raycastSuccessful)
            {
                Vector3 mouseHitPosition = _raycastHit.point;

                // STEP 3 -----------------------------------------------------
                _lastKnownLocation = transform.position;
                _agent.SetDestination(mouseHitPosition);
                
                    



                // STEP 3 -----------------------------------------------------

                // STEP 5 -----------------------------------------------------
               


                // STEP 5 -----------------------------------------------------
            }
        }

        // STEP 6 -------------------------------------------------------------
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _agent.Warp(_lastKnownLocation);
        }


        // STEP 6 -------------------------------------------------------------

        // Uncomment the below line to fix the Pudu's animation if you want.
        _animator.SetBool("isMoving", _agent.velocity.magnitude > 0.0f);
    }
    
    // ------------------------------------------------------------------------
    private void OnDrawGizmos ()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(_mouseRay);

        Gizmos.color = Color.green;
        Gizmos.DrawSphere(_raycastHit.point, 0.2f);
    }
}
