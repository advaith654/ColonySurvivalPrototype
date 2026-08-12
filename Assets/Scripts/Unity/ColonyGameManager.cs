using UnityEngine;

public class ColonyGameManager : MonoBehaviour
{
    [SerializeField] private TextAsset populationJson;
    [SerializeField] private TextAsset consumptionJson;

    private ColonySimulation simulation;

    private float dayTimer;

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
    }
}