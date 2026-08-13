using UnityEngine;
using TMPro;

public class ColonyGameManager : MonoBehaviour
{
    [SerializeField] private TextAsset populationJson;
    [SerializeField] private TextAsset consumptionJson;

    [SerializeField] private TMP_Text gameDayText;
    [SerializeField] private TMP_Text foodText;
    [SerializeField] private TMP_Text foodDaysText;
    [SerializeField] private TMP_Text waterText;
    [SerializeField] private TMP_Text waterDaysText;
    [SerializeField] private TMP_Text starvationText;

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

        UpdateUI();
    }

    private void Update()
    {
        dayTimer += Time.deltaTime;

        if (dayTimer >= SecondsPerGameDay)
        {
            dayTimer -= SecondsPerGameDay;

            AdvanceDay();
        }
    }

    public void AdvanceDayManually()
    {
        AdvanceDay();
    }

    private void AdvanceDay()
    {
        simulation.AdvanceDay();
        UpdateUI();
    }

    private void UpdateUI()
    {
        gameDayText.text =
            "GAME DAY: " + simulation.GameDay;

        foodText.text =
            "FOOD: " + simulation.Food.ToString("0");

        foodDaysText.text =
            "FOOD DAYS: " +
            simulation.GetFoodDaysRemaining().ToString("0.0");

        waterText.text =
            "WATER: " + simulation.Water.ToString("0");

        waterDaysText.text =
            "WATER DAYS: " +
            simulation.GetWaterDaysRemaining().ToString("0.0");

        if (simulation.IsStarving())
        {
            starvationText.text = "COLONY STARVING";
        }
        else
        {
            starvationText.text = "COLONY OK";
        }
    }
}