using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<DroneStats> drones; // Assign all drones in the scene
    public int currentTurnIndex = 0;
    public bool isGameOver = false;

    void Start()
    {
        if (drones == null || drones.Count == 0)
        {
            Debug.LogError("No drones assigned to GameManager.");
            return;
        }

        // Subscribe to health change events for all drones
        foreach (var drone in drones)
        {
            drone.OnHealthChanged += (current, max) =>
            {
                if (current <= 0)
                {
                    RemoveDrone(drone);
                }
            };
        }

        StartTurn();
    }

    void StartTurn()
    {
        if (isGameOver) return;
        DroneStats currentDrone = drones[currentTurnIndex];
        Debug.Log($"Turn: Drone {currentTurnIndex + 1}");
        // Here you can enable input/UI for the current drone
    }

    public void EndTurn()
    {
        if (isGameOver) return;
        currentTurnIndex = (currentTurnIndex + 1) % drones.Count;
        StartTurn();
    }

    public void RemoveDrone(DroneStats drone)
    {
        int index = drones.IndexOf(drone);
        if (index == -1) return;
        drones.RemoveAt(index);
        if (currentTurnIndex >= drones.Count)
            currentTurnIndex = 0;
        if (drones.Count <= 1)
        {
            isGameOver = true;
            Debug.Log("Game Over!");
        }
    }
}
