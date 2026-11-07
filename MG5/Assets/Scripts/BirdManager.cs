using UnityEngine;

public class BirdManager : MonoBehaviour
{
    [SerializeField] private float _interactDistance;
    [SerializeField] private Transform _player;
    [SerializeField] private Bird[] _birds;

    private void Update ()
    {
        // STEP 7 -------------------------------------------------------------
        // This loop is supposed to visit EVERY entry in the _birds array
        //      and not create any errors when the game runs.
        // Uncomment and fix it.
        // You'll only need to fix the for loop () statement itself (line 16).
        // Feature 4 should work after you fix this and add birds to your game.

        for (int i = 0; i < _birds.Length; i++)
        {
            Bird bird = _birds[i];
            if (Vector3.Distance(bird.transform.position, _player.position) <= _interactDistance)
            {
               bird.RunAway(_player.position);
            }
        }
        // STEP 7 -------------------------------------------------------------
    }
}