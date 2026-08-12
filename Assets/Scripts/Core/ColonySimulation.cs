public class ColonySimulation
{
    public int VillagerCount { get; private set; }

    public float Food { get; private set; }
    public float Water { get; private set; }

    public float FoodDailyConsumption { get; private set; }
    public float WaterDailyConsumption { get; private set; }

    public int GameDay { get; private set; }

    public ColonySimulation(
        PopulationConfig population,
        ConsumptionConfig consumption)
    {
        VillagerCount = population.villagerCount;

        Food = population.startingFood;
        Water = population.startingWater;

        FoodDailyConsumption =
            population.villagerCount *
            consumption.foodPerVillagerPerDay;

        WaterDailyConsumption =
            population.villagerCount *
            consumption.waterPerVillagerPerDay;

        GameDay = 0;
    }

    public void AdvanceDay()
    {
        Food -= FoodDailyConsumption;
        Water -= WaterDailyConsumption;

        Food = System.Math.Max(0, Food);
        Water = System.Math.Max(0, Water);

        GameDay++;
    }

    public float GetFoodDaysRemaining()
    {
        if (FoodDailyConsumption <= 0)
            return float.PositiveInfinity;

        return Food / FoodDailyConsumption;
    }

    public float GetWaterDaysRemaining()
    {
        if (WaterDailyConsumption <= 0)
            return float.PositiveInfinity;

        return Water / WaterDailyConsumption;
    }

    public bool IsStarving()
    {
        return Food <= 0 || Water <= 0;
    }
}