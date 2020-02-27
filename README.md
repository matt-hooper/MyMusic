# MyMusic

https://medium.com/swlh/building-a-nice-multi-layer-net-core-3-api-c68a9ef16368

# Install dotnet-ef
dotnet tool install --global dotnet-ef

# restart command window

# Check connection string 
# Ensure Default ConnectionString in MyMusic.Api/appsettings.Development.json is correct (e.g. server, password etc)

# Run database update to Seed DB
dotnet ef --startup-project MyMusic.Api/MyMusic.Api.csproj database update

# Start API project
dotnet run -p MyMusic.Api/MyMusic.Api.csproj