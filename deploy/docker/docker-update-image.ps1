$CUR_DIR = Get-Location
cd ../../../src
$BASE_DIR = Get-Location
dotnet publish 
cd $BASE_DIR/VotingWeb/bin/Debug/netcoreapp2.2/publish
docker compose push
cd $BASE_DIR/VotingData/bin/Debug/netcoreapp2.2/publish
docker compose push
cd $CUR_DIR
