# Curse-IO

Simple package to clean up strings from curse words


## Basic Usage
```
var text = "The quick brown fox jumps over the idiot dog";

var curse = new Curse();

// The quick brown fox jumps over the ***** dog;
var cleanedText = curse.Clear(text);

```

## Setting a language dictionary

It is possible to set a specific language to clear your string. The default one is `English`
```
var curse = new Curse();

curse.SetLanguage(Language.English);

```

## Get bad words cleaned in the string
`Clean` returns a dictionary where key is the bad word and the value is the amount of times it appeared in the given string.

```
var text = "The quick brown fox jumps over the idiot dog";

var curse = new Curse();
IDictionary<string, int> replacedWords;

curse.Clean(text, out replacedWords);

```

## Asynchronous cleaning


```
var text = "The quick brown fox jumps over the idiot dog";

var curse = new Curse();

var cleanedText = await curse.CleanAsync(text);

```

## Languages supported
- English
- Portuguese (BR)
