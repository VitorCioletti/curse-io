# Curse-IO

[![][build-img]][build]
[![][nuget-img]][nuget]

Package to cleanse strings from curse words

[build]:     https://ci.appveyor.com/project/TallesL/fluentscheduler
[build-img]: https://ci.appveyor.com/api/projects/status/github/fluentscheduler/fluentscheduler?svg=true
[nuget]:     https://www.nuget.org/packages/FluentScheduler
[nuget-img]: https://badge.fury.io/nu/fluentscheduler.svg



## Basic Usage
```cs
var text = "The quick brown fox jumps over the idiot dog";

var curse = new Curse();

// The quick brown fox jumps over the ***** dog;
var cleanedText = curse.Clear(text);

```

## Setting a language dictionary

It is possible to set a specific language to clear your string. The default one is `English`
```cs
var curse = new Curse();

curse.SetLanguage(Language.English);

```

## Get bad words cleaned in the string
`Clean` returns a dictionary where key is the bad word and the value is the amount of times it appeared in the given string.

```cs
var text = "The quick brown fox jumps over the idiot dog";

var curse = new Curse();
IDictionary<string, int> replacedWords;

curse.Clean(text, out replacedWords);

```

## Asynchronous cleaning


```cs
var text = "The quick brown fox jumps over the idiot dog";

var curse = new Curse();

var cleanedText = await curse.CleanAsync(text);

```

## Adding words to current dictionary
```cs
var text = "The quick foo fox jumps bar the idiot dog";

var curse = new Curse();

var newCurseWords = new List<string>() {"foo", "bar"};
curse.AddNewWords(newCurseWords);

// The quick *** fox jumps *** the ***** dog
var cleanedText = curse.Clean(text);

```

You can also add only one word
```cs
var curse = new Curse();

curse.AddNewWord("Foo");
```

## Removing words from current dictionary
```cs
var text = "The quick foo fox jumps bar the idiot dog";

var curse = new Curse();

var removeWords = new List<string>() {"foo", "bar", "idiot"};
curse.RemoveWords(removeWords);

// The quick foo fox jumps bar the idiot dog
var cleanedText = curse.Clean(text);

```

You can also remove only one word.
```cs
var curse = new Curse();

curse.RemoveWord("idiot");
```

## Languages supported
- English
- Portuguese (BR)

<p align="center">
    <p>Creative Commons 4.0 International</p>
    <a href="http://creativecommons.org/licenses/by/4.0/">
        <img alt="logo" src="http://i.creativecommons.org/l/by/4.0/80x15.png">
    </a>
</p>
