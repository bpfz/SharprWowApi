using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharprWowApi.Test
{
    public class TestBase
    {
        public WowClient EuClient { get; set; }
        public WowClient UsClient { get; set; }

        public TestBase()
        {
            EuClient = new WowClient(Region.EU, Locale.en_GB, TestConstants.ApiKey);
            EuClient = new WowClient(Region.US, Locale.en_US, TestConstants.ApiKey);
        }
    }
}
