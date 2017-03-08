using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BuspasManager.Models.Charts
{
    public class BarSeriesData
    {
        public String[] x ;
        public int[] y;

        public BarSeriesData(IQueryable<String> seriesDataNames){
            y = new int[seriesDataNames.Count()];
            x = seriesDataNames.ToArray();
            
            //for(int i=0; i < seriesDataNames.Count(); i++){
            //    x[i] = seriesDataNames.ElementAt(i);
            //    y[i] = 0;
            //    }
            }
    }

    public class BarDataModel
    {
        public string label;
        public bool legendEntry = true;
        public BarSeriesData data;

        

    }
}