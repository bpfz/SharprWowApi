## Usage

#####Get achievement By ID
```C#
var client = ApiClient(Region.Eu, Locale.en_GB, ApiKey.Value);
var achievement = client.GetAchievement(2144);
Console.WriteLine(achievement.Title);
```

#####Get Character by realm and name
```C#
var client = new ApiClient(Region.EU, Locale.en_GB, ApiKey.Value);

var characterOne = client.GetCharacter("Grim Batol", "Hjortronsmak", CharacterOptions.None);
var characterTwo = client.GetCharacter("Grim Batol", "xzy", CharacterOptions.GetPvP);

Console.WriteLine(character.Name);
Console.WriteLine(character.Pvp.Brackets.Arena_Bracket_2v2.Rating);
```
