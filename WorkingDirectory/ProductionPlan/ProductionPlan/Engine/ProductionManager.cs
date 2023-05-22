using ProductionPlan.Data;

namespace ProductionPlan.Engine
{
    public class ProductionManager
    {
        private readonly Loader _Loader;

        public ProductionManager(Loader loader)
        {
            _Loader = loader;
        }

        public List<Result> Calculate()
        {
            var finalResults = new List<Result>();
            var windTurbines = _Loader.GetCalculatedWindTurbines((double)this._Loader.Fuels.Wind / 100.0);
            var gasFireds = _Loader.GetCalculcatedGasFired();
            var turboJets = _Loader.GetCalculatedTurboJet();

            var firstSum = windTurbines.Sum(wt => wt.P);

            var currentLoader = this._Loader.Load - firstSum;

            if(currentLoader <= 0)
            {
                gasFireds.ForEach(gf => gf.P = 0);
            }
            else
            {
                int last = 0;
                for(var i = 0; i < gasFireds.Count; i++)
                {
                    var testLoader = currentLoader - gasFireds[i].P;
                    if(testLoader < 0)
                    {
                        gasFireds[i].P += testLoader;
                        currentLoader = 0;
                        last = i;
                        break;
                    }
                    else
                    {
                        currentLoader -= gasFireds[i].P;
                    }
                }                

                if (currentLoader == 0)
                {
                    for (var i = last+1; i < gasFireds.Count; i++)
                    {
                        gasFireds[i].P = 0;
                    }
                    turboJets.ForEach(tj => tj.P = 0);
                }
                else
                {
                    for (var i = 0; i < turboJets.Count; i++)
                    {
                        var testLoader = currentLoader - turboJets[i].P;
                        if (testLoader < 0)
                        {
                            turboJets[i].P -= testLoader;
                            currentLoader = 0;
                            break;
                        }
                        else
                        {
                            currentLoader -= turboJets[i].P;
                        }
                    }
                }
            }

            finalResults.AddRange(windTurbines);
            finalResults.AddRange(gasFireds);
            finalResults.AddRange(turboJets);

            return finalResults;
        }
    }
}
