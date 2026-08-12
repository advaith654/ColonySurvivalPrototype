using UnityEngine;

public class ColonyGameManager : MonoBehaviour
{
    [SerializeField] private TextAsset populationJson;
    [SerializeField] private TextAsset consumptionJson;

    private ColonySimulation simulation;

    private float dayTimer;
    private const float SecondsPerGameDay = 1f;

    private void Start()
    {
        PopulationConfig population =
            JsonUtility.FromJson<PopulationConfig>(
                populationJson.text);

        ConsumptionConfig consumption =
            JsonUtility.FromJson<ConsumptionConfig>(
                consumptionJson.text);

        simulation =
            new ColonySimulation(population, consumption);

        Debug.Log("Colony simulation started.");
        Debug.Log("Food: " + simulation.Food);
        Debug.Log("Water: " + simulation.Water);
    }

    private void Update()
    {
        dayTimer += Time.deltaTime;

        if (dayTimer >= SecondsPerGameDay)
        {
            dayTimer -= SecondsPerGameDay;

            simulation.AdvanceDay();

            Debug.Log(
                "Game Day: " + simulation.GameDay +
                " | Food: " + simulation.Food +
                " | Water: " + simulation.Water
            );

            if (simulation.IsStarving())
            {
                Debug.LogWarning("COLONY STARVING");
            }
        }
    }
}