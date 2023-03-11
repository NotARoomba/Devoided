using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarSpawner : MonoBehaviour
{
    public GameObject game_area;
    public GameObject ship_prefab;

    public int ship_count = 0;
    public int ship_limit = 150;
    public int ships_per_frame = 1;

    public float spawn_circle_radius = 0.1f;
    public float death_circle_radius = 1.0f;

    public float fastest_speed = 1.0f;
    public float slowest_speed = 0.75f;

    void Start()
    {
        InitialPopulation();
    }

    void Update()
    {
        MaintainPopulation();
    }

    void InitialPopulation()
    {
        /** To avoid having to wait for the ships to enter the screen at start up, create an
        initial set of ships for instant action. **/

        for (int i = 0; i < ship_limit; i++)
        {
            Vector3 position = GetRandomPosition(true);
            Star ship_script = AddShip(position);
            ship_script.transform.Rotate(Vector3.forward * Random.Range(0.0f, 360.0f));
        }
    }

    void MaintainPopulation()
    {
        /** Create more ships as old ones are destroyed, while respecting the object limit. **/

        if (ship_count < ship_limit)
        {
            for (int i = 0; i < ships_per_frame; i++)
            {
                Vector3 position = GetRandomPosition(false);
                Star ship_script = AddShip(position);
                ship_script.transform.Rotate(Vector3.forward * Random.Range(-45.0f, 45.0f));
            }
        }
    }

    Vector3 GetRandomPosition(bool within_camera)
    {
        /** Get a random spawn position, using a 2D circle around the game area. **/

        Vector3 position = Random.insideUnitCircle;

        if (within_camera == false)
        {
            position = position.normalized;
        }

        position *= spawn_circle_radius;
        position += game_area.transform.position;

        return position;
    }

    Star AddShip(Vector3 position)
    {
        /**Add a new ship to the game and set the basic attributes. **/

        ship_count += 1;
        GameObject new_ship = Instantiate(
            ship_prefab,
            position,
            Quaternion.FromToRotation(Vector3.up, (game_area.transform.position - position)),
            gameObject.transform
        );

        Star ship_script = new_ship.GetComponent<Star>();
        ship_script.ship_spawner = this;
        ship_script.game_area = game_area;
        ship_script.speed = Random.Range(slowest_speed, fastest_speed);

        return ship_script;
    }
}