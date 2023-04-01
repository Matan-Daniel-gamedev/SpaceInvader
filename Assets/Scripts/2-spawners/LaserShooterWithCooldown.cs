using UnityEngine;

/**
 * This component spawns the given laser-prefab whenever the player clicks a given key.
 * It also updates the "scoreText" field of the new laser.
 */
public class LaserShooterWithCooldown: ClickSpawner
{
    [SerializeField] NumberField scoreField;
    [SerializeField] float cooldownTime = 0.5f;
    float nextTime = 0.0f;

    protected override GameObject spawnObject()
    {
        if (Time.time > nextTime)
        {
            nextTime = Time.time + cooldownTime;

            GameObject newObject = base.spawnObject();  // base = super

            // Modify the text field of the new object.
            ScoreAdder newObjectScoreAdder = newObject.GetComponent<ScoreAdder>();
            if (newObjectScoreAdder)
                newObjectScoreAdder.SetScoreField(scoreField);

            return newObject;
        }
        else
        {
            return null;
        }
    }
}
