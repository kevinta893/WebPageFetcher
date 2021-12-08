FROM mcr.microsoft.com/dotnet/sdk:5.0-focal
RUN git clone https://github.com/kevinta893/WebPageFetcher.git
RUN dotnet publish WebPageFetcher/WebPageFetcher/WebPageFetcher -r linux-x64 --configuration Release --nologo -p:PublishSingleFile=true --self-contained true -o ./Publish
ENTRYPOINT ["./Publish/WebPageFetcher"]