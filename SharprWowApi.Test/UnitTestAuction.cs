﻿using System;
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
            var explorer = new ApiClient(Region.EU, Locale.en_GB, ApiKey.Value);
            var getAuction = explorer.GetAuctions("Grim batol");
            var auction = getAuction.Auctions.Auctions;

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

        [TestMethod]
        public async Task Test_Get_EU_AuctionDataAsync()
        {
            var explorer = new ApiClient(Region.EU, Locale.en_GB, ApiKey.Value);
            var getAuction = await explorer.GetAuctionsAsync("Grim batol");
            var auction = getAuction.Auctions.Auctions;

            string owner = "";
            foreach (var a in auction.Take(5))
            {
                Assert.IsNotNull(a.Auc);
                Assert.IsNotNull(a.Bid);
                Assert.IsNotNull(a.Buyout);
                Assert.IsNotNull(a.Context);
                Assert.IsNotNull(a.Item);

                owner = a.Owner;

            }
            Console.WriteLine(owner);
        }
    }
}