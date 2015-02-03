using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SharprWowApi.Test
{
    [TestClass]
    public class UnitTestAuction
    {
        [TestMethod]
        public void Test_Get_EU_AuctionData()
        {
            var client = new ApiClient(Region.EU, Locale.en_GB, TestConstants.ApiKey);

            var getAuctionFile = client.GetAuctionFile(TestConstants.EU_en_GB_Realm);

            var someCachedValue = "14218549882000";

            var lm = from f in getAuctionFile.Files
                     select f.LastModified;

            if (!lm.Equals(someCachedValue))
            {

                var getAuction = client.GetAuctions(TestConstants.EU_en_GB_Realm);
                var auction = getAuction.Auctions.Auction;

                string owner = "";
                foreach (var a in auction.Take(5))
                {
                    Assert.IsNotNull(a.Bid);
                    Assert.IsNotNull(a.Buyout);
                    Assert.IsNotNull(a.Context);
                    Assert.IsNotNull(a.Item);

                    owner = a.Owner;

                }
                Console.WriteLine(owner);

            }
        }

        [TestMethod]
        public async Task Test_Get_EU_AuctionDataAsync()
        {
            var client = new ApiClient(Region.EU, Locale.en_GB, TestConstants.ApiKey);

            var getAuctionFile = client.GetAuctionFile(TestConstants.EU_en_GB_Realm);
            var someCachedValue = "14218549882000";

            var lm = from f in getAuctionFile.Files
                     select f.LastModified;

            if (!lm.Equals(someCachedValue))
            {

                var getAuction = await client.GetAuctionsAsync(TestConstants.EU_en_GB_Realm);
                var auction = getAuction.Auctions.Auction;

                string owner = "";

                using (auction.GetEnumerator())
                {
                    Parallel.ForEach(auction.Take(5), a =>
                    {
                        Assert.IsNotNull(a.Auc);
                        Assert.IsNotNull(a.Bid);
                        Assert.IsNotNull(a.Buyout);
                        Assert.IsNotNull(a.Context);
                        Assert.IsNotNull(a.Item);
                        owner = a.Owner;
                        Console.WriteLine(owner);
                    });
                }

            }
        }
    }
}
