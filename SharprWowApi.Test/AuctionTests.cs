using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Diagnostics;

namespace SharprWowApi.Test
{
    [TestClass]
    public class AuctionTests : TestBase
    {
        [TestMethod]
        [TestCategory("Auction")]
        public async Task Get_EU_AuctionData()
        {
            var getAuctionFile = await EuClient.GetAuctionFileAsync(TestConstants.EU_en_GB_Realm);
            var someCachedValue = "14218549882000";

            var lm = from f in getAuctionFile.Files
                     select f.LastModified;

            if (!lm.Equals(someCachedValue))
            {
                var getAuction = await EuClient.GetAuctionsAsync(TestConstants.EU_en_GB_Realm);
                var auction = getAuction.Auctions;

                string owner = "";
                foreach (var a in auction.Take(51))
                {
                    Assert.IsNotNull(a.Bid);
                    Assert.IsNotNull(a.Buyout);
                    Assert.IsNotNull(a.Context);
                    Assert.IsNotNull(a.Item);

                    Console.WriteLine(a.Item);
                    Console.WriteLine(a.Bid);
                    Console.WriteLine(a.BidGold);
                    Console.WriteLine(a.BidSilver);
                    Console.WriteLine(a.BidCopper);
                    Console.WriteLine("-------------------");
                    owner = a.Owner;
                }
            }
        }

        [TestMethod]
        [TestCategory("Auction")]
        public async Task US_GetAuctionData()
        {
            var auctions = await EuClient.GetAuctionsAsync(TestConstants.US_en_US_Realm);
            Assert.IsNotNull(auctions);

            Parallel.ForEach(auctions.Auctions.Take(150), auction =>
                 {
                     Assert.IsNotNull(auction.Auc);
                     Assert.IsNotNull(auction.Bid);
                     Assert.IsNotNull(auction.Buyout);
                     Assert.IsNotNull(auction.Context);
                     Assert.IsNotNull(auction.Item);
                 });
        }

        [TestMethod]
        [TestCategory("Auction")]
        public async Task Get_AuctionDataAsync()
        {
            var getAuctionFile = await EuClient.GetAuctionFileAsync(TestConstants.EU_en_GB_Realm);
            var someCachedValue = "14218549882000";

            var lm = from f in getAuctionFile.Files
                     select f.LastModified;

            if (!lm.Equals(someCachedValue))
            {

                var getAuction = await EuClient.GetAuctionsAsync(TestConstants.EU_en_GB_Realm);
                var auction = getAuction.Auctions;

                string owner = "";
                using (auction.GetEnumerator())
                {
                    Parallel.ForEach(auction.Take(51), a =>
                    {
                        Assert.IsNotNull(a.Auc);
                        Assert.IsNotNull(a.Bid);
                        Assert.IsNotNull(a.Buyout);
                        Assert.IsNotNull(a.Context);
                        Assert.IsNotNull(a.Item);
                        owner = a.Owner;

                        Console.WriteLine(a.BidGold);
                        Console.WriteLine(a.BidSilver);
                        Console.WriteLine(a.BidCopper);

                    });
                }
            }
        }
    }
}
