### SharprWowApi
SharprWowApi is a strongly typed .NET wrapper library for accessing and retrieving data from [Blizzards WoW API](https://dev.battle.net/).

Install using [Nuget](https://www.nuget.org/packages/SharprWowApi/)
````
PM> Install-Package SharprWowApi
````

[Small example website (not maintained)](http://sharpr.azurewebsites.net/)

## Usage example

##### Get achievement By ID

```c#
var client = WowClient(Region.Eu, Locale.en_GB, ApiKey.Value);
var achievement = await client.GetAchievementAsync(2144);
Console.WriteLine(achievement.Title);
```  

##### Get Character by realm and name

```c#
var client = new WowClient(Region.EU, Locale.en_GB, ApiKey.Value);

var characterOne = await client.GetCharacterAsync("CharacterName", CharacterOptions.None, "Realm");
var characterTwo = await client.GetCharacterAsync("CharacterName", CharacterOptions.PvP, "Realm");

Console.WriteLine(character.Name);
Console.WriteLine(characterTwo.Pvp.Brackets.ArenaBracket2v2.Rating);
```
You can also set __realm__ in the _WowClient_ and use overloaded methods if all characters you're getting are from the same realm.

```C#
client = new WowClient(Region.EU, Locale.en_GB, ApiKey.Value, "Realm");

var characterOne = await client.GetCharacterAsync("CharacterName", CharacterOptions.None);
var characterTwo = await client.GetCharacterAsync("CharacterName", CharacterOptions.None);
var characterThree = await client.GetCharacterAsync("CharacterName", CharacterOptions.None);

Console.WriteLine(characterOne.Name);
Console.WriteLine(characterTwo.Name);
Console.WriteLine(characterThree.Name);
```
##### Create your own Guild & CharacterOptions (v1.0.2)
Can be useful if you need to retrieve more than a single field but less than all.
```C#
var options = GuildOptions.Members | GuildOptions.Challenge;
var guild = await client.GetGuildAsync("GuildName", options, "Realm");
...
```
##### Async
Since some of the data returned by blizzards wow API is quite big (especially auction data & PVP leaderboard), it can be a good idea to use the async methods even though the json parsing is not async. Since it offloads the json deserialization to a new thread.  (https://github.com/JamesNK/Newtonsoft.Json/issues/66). 

And even though the deserialization isn't async it stills downloads the json asynchronously.

```C#
var client = new WowClient(Region.EU, Locale.en_GB, ApiKey.Value);

//await
var getAuctionFile = await client.GetAuctionFileAsync("Realm");
var someCachedValue = "...";

//Check when the auctiondata was last modified (updated)
var lm = from f in getAuctionFile.Files
            select f.LastModified;

  if (!lm.Equals(someCachedValue))
  {
    //await here
    var getAuction = await client.GetAuctionsAsync("Realm");
    var auction = getAuction.Auctions
    
       Parallel.ForEach(auction.Take(10), a =>
       {
         Console.WriteLine(a.Item);
       });
 ...
```
#### Get all members from a guild as Character objects (1.1)
A signifcant speed increase compared to a synchronous operation. It's worth noting that if you try to parse a guild with too many members (without setting how many members to take to a low enough number) and the amount of requests to the api gets too high, you will get a 403 (forbidden) error. 

![Async vs Sync Test](http://i.imgur.com/nuCpGjQ.jpg)

Both test cases used the same list of (64) members. They both Get Character (GetCharacterAsync & GetCharacter) and adds the result to a list.

```C#
var client = new ApiClientAsync(Region, Locale, apiKey)
var guild = await client.GetGuildAsync("GuildName", GuildOptions.Members);

var charc = await 
    client.GetAllCharactersInGuildAsync(
        guild.Members, 
        CharacterOptions.AllOptions,
        int level,
        int HowManyMembersToTake);

```
The method sorts users by level first and then takes the set amount.

##### as of 1.2 all non-async functionality is removed, ApiClient name changed to WowClient
