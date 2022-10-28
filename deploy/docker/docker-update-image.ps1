$CUR_DIR = Get-Location
cd ../../../src
$BASE_DIR = Get-Location

# when deploying Voting app
# dotnet publish 
# cd $BASE_DIR/VotingWeb/bin/Debug/netcoreapp2.2/publish
# docker compose push
# cd $BASE_DIR/VotingData/bin/Debug/netcoreapp2.2/publish
# docker compose push
# cd $BASE_DIR/gateway/Ocelot.Demo/Ocelot.Demo/bin/Debug/net6.0/publish
# docker compose push

# when deploying Inspection app
# cd $BASE_DIR/InspectionApp/angular-app
# docker compose build
# docker compose push
cd $BASE_DIR/InspectionApp/dotnet-api/InspectionAPI
docker compose build
docker compose push
cd $BASE_DIR/InspectionApp/Ocelot.Demo/Ocelot.Demo
docker compose build
docker compose push
cd $CUR_DIR
