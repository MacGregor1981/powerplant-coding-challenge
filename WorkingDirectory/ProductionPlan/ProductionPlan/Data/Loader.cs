
using ProductionPlan.Data.Enums;
using System.Text.Json.Serialization;

namespace ProductionPlan.Data
{
    public class Loader
    {
        [JsonPropertyName("load")]
        public int Load { get; set; }

        [JsonPropertyName("fuels")]
        public Fuels Fuels { get; set; }

        [JsonPropertyName("powerplants")]
        public List<PowerPlant> PowerPlants { get; set; }

        private List<PowerPlant> GetSpecificPowerPlantsType(PowerPlantType powerPlantType) 
        {
            if(PowerPlants.Count > 0) 
            {
                return PowerPlants.Where(ppt => ppt.Type == powerPlantType.ToString()).ToList();
            }
            return new List<PowerPlant>();
        }

        public List<Result> GetCalculatedWindTurbines(double windPercentage)
        {
            var windTurbines = GetSpecificPowerPlantsType(PowerPlantType.windturbine);

            List<Result> result = windTurbines.Select(wt => new Result
                {
                    Name = wt.Name,
                    P = (int)((double)wt.PMax * (wt.Efficiency * windPercentage)),
                })
                .OrderByDescending(r => r.P)
                .ToList();

            return result;
        }

        public List<Result> GetCalculcatedGasFired()
        {
            var gasfired = GetSpecificPowerPlantsType(PowerPlantType.gasfired);

            List<Result> result = gasfired.Select(gf => new Result
            {
                Name = gf.Name,
                P = (int)((double)gf.PMax * gf.Efficiency)
            }).OrderByDescending(r => r.P).ToList();

            return result;
        }

        public List<Result> GetCalculatedTurboJet()
        {
            var turboJet = GetSpecificPowerPlantsType(PowerPlantType.turbojet);

            List<Result> result = turboJet.Select(gf => new Result
            {
                Name = gf.Name,
                P = (int)((double)gf.PMax * gf.Efficiency)
            }).OrderByDescending(r => r.P).ToList();

            return result;
        }
    }
}
