using System.Collections;
using UnityEngine;
public class worldManager : MonoBehaviour
{
    [Header("Worlds")]
    [SerializeField] private GameObject redWorld;
    [SerializeField] private GameObject blueWorld;

    [Header("Timer Variables")]
    public float cooldownTime = 3f;
    public bool isCooldown = false;

    private void Awake()
    {
        deactivateWorld(redWorld);
        deactivateWorld(blueWorld);
    }

    void Update()
    { 
            // activate the red world
            if (Input.GetKeyDown(KeyCode.G) && !isCooldown)
            {
            // if the world is already active dont do anything
                if (redWorld.activeInHierarchy == false)
                {
                    isCooldown = true;
                    Debug.Log("Changing the active world to red");
                    activateWorld(redWorld);
                    deactivateWorld(blueWorld);
                    StartCoroutine(ResetCooldown());
                }
            }

            // activate the blue world
            if (Input.GetKeyDown(KeyCode.H) && !isCooldown)
            {
                // if the world is already active dont do anything
                if (blueWorld.activeInHierarchy == false)
                {
                    isCooldown = true;
                    Debug.Log("Changing the active world to blue");
                    activateWorld(blueWorld);
                    deactivateWorld(redWorld);
                    StartCoroutine(ResetCooldown());
            }
            }
    }

    /// <summary>
    /// Activates worlds by using .SetActive(true)
    /// </summary>
    /// <param name="world"></param> game object that is being activated
    private void activateWorld(GameObject world)
    {
        world.SetActive(true);
    }

    /// <summary>
    /// Deactivates worlds by using .SetActive(false)
    /// </summary>
    /// <param name="world"></param> game object that is being deactivated
    private void deactivateWorld(GameObject world)
    {
        world.SetActive(false);
    }

    IEnumerator ResetCooldown()
    {
        yield return new WaitForSeconds(cooldownTime);
        isCooldown = false;
    }
}
