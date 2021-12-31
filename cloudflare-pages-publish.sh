curl -sSL https://dot.net/v1/dotnet-install.sh > dotnet-install.sh;
chmod +x dotnet-install.sh;
./dotnet-install.sh -c 6.0 -InstallDir ./dotnet6;
./dotnet6/dotnet --version;
./dotnet6/dotnet tool restore;
./dotnet6/dotnet tool run webcompiler -- -r ./libanvl.monkey.theme/ -c ./libanvl.monkey.theme/webcompilerconfiguration.json;
./dotnet6/dotnet publish libanvl.monkey/libanvl.monkey.csproj -c Release -o output -p:SkipToolUpdate=true;
