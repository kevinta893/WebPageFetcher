# WebPageFetcher
A CLI that fetches an HTML web page and saves it as a file.


## How to run

Enter a list of URLs separated by space. Add an additional --metadata flag to also print metadata about the webpage:

```
./WebPageFetcher --metadata https://github.com https://reddit.com
```

## Build

Build for Linux-x64

```
dotnet publish WebPageFetcher -r linux-x64 --configuration Release --nologo -p:PublishSingleFile=true --self-contained true -o ./Publish
```