using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharprWowApi.DiabloModels.DataResources
{
    class FollowerData
    {
    }
    public class Active
{
    public string slug { get; set; }
    public string name { get; set; }
    public string icon { get; set; }
    public int level { get; set; }
    public string tooltipUrl { get; set; }
    public string description { get; set; }
    public string simpleDescription { get; set; }
    public string skillCalcId { get; set; }
}

public class Skills
{
    public List<Active> active { get; set; }
    public List<object> passive { get; set; }
}

public class RootObject
{
    public string slug { get; set; }
    public string name { get; set; }
    public string realName { get; set; }
    public string portrait { get; set; }
    public Skills skills { get; set; }
}
}
