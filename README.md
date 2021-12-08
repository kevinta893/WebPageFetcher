# WebPageFetcher
A CLI that fetches a web page and saves it as a file.


## Build

Build for Linux-x64

```
dotnet publish WebPageFetcher -r linux-x64 --configuration Release --nologo -p:PublishSingleFile=true --self-contained true -o ./Publish
```