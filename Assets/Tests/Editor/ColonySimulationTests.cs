using NUnit.Framework;

public class ColonySimulationTests
{
    [Test]
    public void AdvanceDay_DeductsCorrectFoodAndWater()
    {
        PopulationConfig population = new PopulationConfig
        {
            villagerCount = 10,
            startingFood = 100,
            startingWater = 100
        };

        ConsumptionConfig consumption = new ConsumptionConfig
        {
            foodPerVillagerPerDay = 2,
            waterPerVillagerPerDay = 1
        };

        ColonySimulation simulation =
            new ColonySimulation(population, consumption);

        simulation.AdvanceDay();

        Assert.AreEqual(80, simulation.Food);
        Assert.AreEqual(90, simulation.Water);
        Assert.AreEqual(1, simulation.GameDay);
    }

    [Test]
    public void DaysRemaining_IsCalculatedCorrectly()
    {
        PopulationConfig population = new PopulationConfig
        {
            villagerCount = 10,
            startingFood = 100,
            startingWater = 100
        };

        ConsumptionConfig consumption = new ConsumptionConfig
        {
            foodPerVillagerPerDay = 2,
            waterPerVillagerPerDay = 1
        };

        ColonySimulation simulation =
            new ColonySimulation(population, consumption);

        Assert.AreEqual(5f, simulation.GetFoodDaysRemaining());
        Assert.AreEqual(10f, simulation.GetWaterDaysRemaining());
    }

    [Test]
    public void Starving_WhenEitherReserveReachesZero()
    {
        PopulationConfig population = new PopulationConfig
        {
            villagerCount = 10,
            startingFood = 20,
            startingWater = 100
        };

        ConsumptionConfig consumption = new ConsumptionConfig
        {
            foodPerVillagerPerDay = 2,
            waterPerVillagerPerDay = 1
        };

        ColonySimulation simulation =
            new ColonySimulation(population, consumption);

        simulation.AdvanceDay();

        Assert.IsTrue(simulation.IsStarving());
    }
}